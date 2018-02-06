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
    public partial class CameraPage : ContentPage
    {
        private string url;
        static string requestUrl;
        private int c_bool;
        private string _device;

        public CameraPage()
        {
            InitializeComponent();

            url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1051637750796067320&formatVersion=2"; //formatVersion=2にした

            _device = Device.Idiom.ToString();
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

                // PopAsyncで元のページに戻り、結果を表示
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //phoneならこっち
                    if (_device == "Phone")
                    {
                        List<Manage> hoge2;
                        hoge2 = Manage._camera();
                        if (hoge2 == null)
                        {
                            Manage.insertCamera();
                            hoge2 = Manage._camera();
                        }
                        foreach (var x in hoge2)
                        {
                            c_bool = x.camera_bool;
                        }

                        if (c_bool == 0)
                        {
                            DependencyService.Get<IDeviceService>().PlayVibrate();
                            await Navigation.PopAsync();//元のページに戻る
                        }
                        if (c_bool == 1)
                        {
                            DependencyService.Get<IDeviceService>().PlayVibrate();
                            scanPage.IsScanning = false;
                        }
                    }
                    //タブレットならこっち
                    else
                    {
                        if (c_bool == 0)
                        {
                            await Navigation.PopAsync();//元のページに戻る
                        }
                        if (c_bool == 1)
                        {
                        }
                    }

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

                        JValue subTiv = (JValue)jobj["subTitle"];
                        string subTitle = (string)subTiv.Value;

                        JValue subTiKv = (JValue)jobj["subTitleKana"];
                        string subTitleKana = (string)subTiKv.Value;

                        JValue authorValue = (JValue)jobj["author"];
                        string author = (string)authorValue.Value;

                        JValue authorKanaValue = (JValue)jobj["authorKana"];
                        string authorKana = (string)authorKanaValue.Value;

                        JValue pubV = (JValue)jobj["publisherName"];
                        string publisher = (string)pubV.Value;

                        JValue sizeV = (JValue)jobj["size"];
                        string size = (string)sizeV.Value;

                        JValue isbnValue = (JValue)jobj["isbn"];
                        string isbn = (string)isbnValue.Value;

                        JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                        string itemCaption = (string)itemCaptionValue.Value;

                        JValue salesDateV = (JValue)jobj["salesDate"];
                        string salesDate = (string)salesDateV.Value;

                        JValue priceV = (JValue)jobj["itemPrice"];
                        var priceVV = priceV.ToString();
                        int price = int.Parse(priceVV);

                        JValue gazoValue = (JValue)jobj["largeImageUrl"];
                        string gazo = (string)gazoValue.Value;

                        JValue genreV = (JValue)jobj["booksGenreId"];
                        string genreId = (string)genreV.Value;



                        bool x = await DisplayAlert("この内容で登録してよろしいですか？", "タイトル:" + title + "\r\n著者:" + author, "OK", "CANCEL");
                        if (x == true)
                        {
                            BookDB.insertBook(isbn, title, titleKana, subTitle, subTitleKana, author, authorKana, publisher, size, itemCaption, salesDate, price, gazo, genreId);
                        }
                        if (title == null)
                        {
                            await DisplayAlert("警告", "本が楽天ブックスに登録されていない可能性があります", "OK");
                        }
                        if (scanPage.IsScanning == false)
                        {
                            scanPage.IsScanning = true;
                        }
                    };
                });
            };
        }

        async void SerchClicked(object sender, EventArgs e)
        {
            try
            {
                requestUrl = url + "&isbn=" + serch_isbn.Text; //URLにISBNコードを挿入

                //HTTPアクセスメソッドを呼び出す
                string APIdata = await GetApiAsync(); //jsonをstringで受け取る

                //HTTPアクセス失敗処理(404エラーとか名前解決失敗とかタイムアウトとか)
                if (APIdata is null)
                {
                    await DisplayAlert("接続エラー", "接続に失敗しました", "OK");
                }

                /*
                //レスポンス(JSON)をstringに変換-------------->しなくていい
                Stream s = GetMemoryStream(APIdata); //GetMemoryStreamメソッド呼び出し
                StreamReader sr = new StreamReader(s);
                string json = sr.ReadToEnd();
                */
                /*
                //デシリアライズ------------------>しなくていい
                var rakutenBooks = JsonConvert.DeserializeObject<RakutenBooks>(json.ToString());
                */

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

                    JValue subTiv = (JValue)jobj["subTitle"];
                    string subTitle = (string)subTiv.Value;

                    JValue subTiKv = (JValue)jobj["subTitleKana"];
                    string subTitleKana = (string)subTiKv.Value;

                    JValue authorValue = (JValue)jobj["author"];
                    string author = (string)authorValue.Value;

                    JValue authorKanaValue = (JValue)jobj["authorKana"];
                    string authorKana = (string)authorKanaValue.Value;

                    JValue pubV = (JValue)jobj["publisherName"];
                    string publisher = (string)pubV.Value;

                    JValue sizeV = (JValue)jobj["size"];
                    string size = (string)sizeV.Value;

                    JValue isbnValue = (JValue)jobj["isbn"];
                    string isbn = (string)isbnValue.Value;

                    JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                    string itemCaption = (string)itemCaptionValue.Value;

                    JValue salesDateV = (JValue)jobj["salesDate"];
                    string salesDate = (string)salesDateV.Value;

                    JValue priceV = (JValue)jobj["itemPrice"];
                    var priceVV = priceV.ToString();
                    int price = int.Parse(priceVV);

                    JValue gazoValue = (JValue)jobj["largeImageUrl"];
                    string gazo = (string)gazoValue.Value;

                    JValue genreV = (JValue)jobj["booksGenreId"];
                    string genreId = (string)genreV.Value;


                    bool x = await DisplayAlert("この内容で登録してよろしいですか？", "タイトル:" + title + "\r\n著者:" + author, "OK", "CANCEL");
                    if (x == true)
                    {
                        BookDB.insertBook(isbn, title, titleKana, subTitle, subTitleKana, author, authorKana, publisher, size, itemCaption, salesDate, price, gazo, genreId);
                    }


                };
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.ToString(), "ok"); //デバック用なのでリリース時は削除かコメントアウト
                //try catch自体は置いとかないと落ちそう
            }
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
