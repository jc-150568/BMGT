using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ZXing.Net.Mobile.Forms;

namespace book3
{
    /*
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
        }
        async void ScanButtonClicked(object sender, EventArgs s)
        {
            var scanPage = new ZXingScannerPage()
            {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };

            // スキャナページを表示
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // スキャン停止
                scanPage.IsScanning = false;

                // PopAsyncで元のページに戻り、結果をダイアログで表示
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("スキャン完了", result.Text, "OK");
                });

                //scanedData.Add(result.Text);
            };
        }
    }
    */
    public partial class CameraPage : ContentPage
    {
        private string url;
        static string requestUrl;

        public CameraPage()
        {
            InitializeComponent();

            url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1051637750796067320&formatVersion=2"; //formatVersion=2にした
        }
        async void ScanButtonClicked(object sender, EventArgs s)
        {
            var scanPage = new ZXingScannerPage()
            {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };

            // スキャナページを表示
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // スキャン停止
                scanPage.IsScanning = false;

                // PopAsyncで元のページに戻り、結果をダイアログで表示
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    string isbncode = result.Text;
                    requestUrl = url + "&isbn=" + isbncode; //URLにISBNコードを挿入

                    //HTTPアクセスメソッドを呼び出す
                    string APIdata = await GetApiAsync(); //jsonをstringで受け取る

                    //パースする *重要*   パースとは、文法に従って分析する、品詞を記述する、構文解析する、などの意味を持つ英単語。
                    var json = JObject.Parse(APIdata); //stringのAPIdataをJObjectにパース
                    var Items = JArray.Parse(json["Items"].ToString()); //Itemsは配列なのでJArrayにパース

                    //結果を出力
                    foreach (JObject jobj in Items)
                    {
                        //↓のように取り出す
                        JValue titleValue = (JValue)jobj["title"];
                        string title = (string)titleValue.Value;

                        JValue titleKanaValue = (JValue)jobj["titleKana"];
                        string titleKana = (string)titleKanaValue.Value;

                        JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                        string itemCaption = (string)itemCaptionValue.Value;

                        JValue gazoValue = (JValue)jobj["largeImageUrl"];
                        string gazo = (string)gazoValue.Value;

                        JValue isbnValue = (JValue)jobj["isbn"];
                        string isbn = (string)isbnValue.Value;

                        BookDB.insertBook(isbn, title, titleKana, itemCaption);
                    };

                    var layout2 = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                    var scroll = new ScrollView { Orientation = ScrollOrientation.Vertical };
                    layout2.Children.Add(scroll);
                    var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                    scroll.Content = layout;

                    if (BookDB.select_all() != null) //全部表示
                    {
                        var query = BookDB.select_all(); //中身はSELECT * FROM [User] limit 15

                        foreach (var book in query)
                        {
                            //Userテーブルの名前列をLabelに書き出します
                            layout.Children.Add(new Label { Text = book.ISBN });
                            layout.Children.Add(new Label { Text = book.Title });
                            layout.Children.Add(new Label { Text = book.TitleKana });
                            layout.Children.Add(new Label { Text = book.ItemCaption });
                        }
                    }
                    else
                    {
                        await DisplayAlert("表がないエラー", "表がないよー", "OK");
                    }

                    Content = layout;
                });
            };
        }

        void SelectClicked(object sender, EventArgs s)
        {
            var layout2 = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            var scroll = new ScrollView { Orientation = ScrollOrientation.Vertical };
            layout2.Children.Add(scroll);
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            scroll.Content = layout;

            if (BookDB.select_all() != null) //全部表示
            {
                var query = BookDB.select_all(); //中身はSELECT * FROM [User] limit 15

                foreach (var book in query)
                {
                    //Userテーブルの名前列をLabelに書き出します
                    layout.Children.Add(new Label { Text = book.ISBN.ToString() });
                    layout.Children.Add(new Label { Text = book.Title });
                    layout.Children.Add(new Label { Text = book.TitleKana });
                    layout.Children.Add(new Label { Text = book.ItemCaption });
                }
            }
            else
            {
                DisplayAlert("表がないエラー", "表がないよー", "OK");
            }

            Content = layout;
        }

        //HTTPアクセスメソッド
        public static async Task<string> GetApiAsync()
        {
            string APIurl = requestUrl;

            using (HttpClient client = new HttpClient())
                try
                {
                    string urlContents = await client.GetStringAsync(APIurl);
                    await Task.Delay(1000); //1秒待つ(楽天API規約に違反するため)
                    return urlContents;
                }
                catch (Exception e)
                {
                    string a = e.ToString();
                    return null;
                }
        }
    }
}