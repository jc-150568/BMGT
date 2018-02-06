using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeekPage : ContentPage
    {
        private string url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&formatVersion=2&applicationId=1051637750796067320&sort=sales&hits=30";
        static string requestUrl;
        static string genreid = "";
        static string genre2 = "";
        
        public ObservableCollection<Book2> items = new ObservableCollection<Book2>();

        public SeekPage()
        {

            InitializeComponent();


        }

        
        public class Book2
        {
            public string Name { get; set; }

            public double Value { get; set; }

            public string ValueImage { get; set; }

            public bool RedStar { get; set; }

            public string RedStar2 { get; set; }

            public bool BlueBook { get; set; }

            public string BlueBook2 { get; set; }

        }

        // 親カテゴリのプルダウンに応じて子カテゴリの内容を変更する
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            try
            {

                if (this.picker2.SelectedIndex == 0)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("少年");
                    picker3.Items.Add("少女");
                    picker3.Items.Add("青年");
                    picker3.Items.Add("レディース");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 1)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("語学学習");
                    picker3.Items.Add("語学辞書");
                    picker3.Items.Add("辞典");
                    picker3.Items.Add("語学関係資格");
                    picker3.Items.Add("学習参考書・問題書");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 2)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("児童書");
                    picker3.Items.Add("自動文庫");
                    picker3.Items.Add("絵本");
                    picker3.Items.Add("民話・昔話");
                    picker3.Items.Add("しかけ絵本");
                    picker3.Items.Add("図鑑・知識");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }


                if (this.picker2.SelectedIndex == 3)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("ミステリー・サスペンス");
                    picker3.Items.Add("SF・ホラー");
                    picker3.Items.Add("エッセイ");
                    picker3.Items.Add("ノンフィクション");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 4)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("ハードウェア");
                    picker3.Items.Add("入門書");
                    picker3.Items.Add("インターネット・WEBデザイン");
                    picker3.Items.Add("ネットワーク");
                    picker3.Items.Add("プログラミング");
                    picker3.Items.Add("アプリケーション");
                    picker3.Items.Add("OS");
                    picker3.Items.Add("デザイン・グラフィックス");
                    picker3.Items.Add("ITパスポート");
                    picker3.Items.Add("MOUS・MOT");
                    picker3.Items.Add("パソコン検定");
                    picker3.Items.Add("IT・eコマース");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 5)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("経済・財政");
                    picker3.Items.Add("流通");
                    picker3.Items.Add("IT・eコマース");
                    picker3.Items.Add("マーケティング・セールス");
                    picker3.Items.Add("投資・株・資産運用");
                    picker3.Items.Add("マネープラン");
                    picker3.Items.Add("マネジメント・人材管理");
                    picker3.Items.Add("経理");
                    picker3.Items.Add("自己啓発");
                    picker3.Items.Add("就職・転職");
                    picker3.Items.Add("MBA");
                    picker3.Items.Add("証券アナリスト");
                    picker3.Items.Add("税理士・公認会計士・ファイナンシャルプランナー");
                    picker3.Items.Add("簿記検定");
                    picker3.Items.Add("銀行・金融検定");
                    picker3.Items.Add("経営");
                    picker3.Items.Add("産業");
                    picker3.Items.Add("その他");
                    picker3.Items.Add("アフィリエイト");
                    picker3.Items.Add("ビジネスマナー");
                    picker3.Items.Add("金融");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 6)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("旅");
                    picker3.Items.Add("温泉");
                    picker3.Items.Add("鉄道の旅");
                    picker3.Items.Add("テーマパーク");
                    picker3.Items.Add("ガイドブック");
                    picker3.Items.Add("地図");
                    picker3.Items.Add("留学・海外赴任");
                    picker3.Items.Add("旅行主任者");
                    picker3.Items.Add("紀行・旅行エッセイ");
                    picker3.Items.Add("釣り");
                    picker3.Items.Add("その他");
                    picker3.Items.Add("キャンプ");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 7)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("雑学・出版・ジャーナリズム");
                    picker3.Items.Add("哲学・思想");
                    picker3.Items.Add("心理学");
                    picker3.Items.Add("宗教・倫理");
                    picker3.Items.Add("歴史");
                    picker3.Items.Add("社会科学");
                    picker3.Items.Add("法律");
                    picker3.Items.Add("政治");
                    picker3.Items.Add("社会");
                    picker3.Items.Add("教育・福祉");
                    picker3.Items.Add("民俗");
                    picker3.Items.Add("軍事");
                    picker3.Items.Add("ノンフィクション");
                    picker3.Items.Add("言語学");
                    picker3.Items.Add("文学");
                    picker3.Items.Add("その他");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 8)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("スポーツ");
                    picker3.Items.Add("格闘技");
                    picker3.Items.Add("車・バイク");
                    picker3.Items.Add("鉄道");
                    picker3.Items.Add("登山・アウトドア・釣り");
                    picker3.Items.Add("カメラ・写真");
                    picker3.Items.Add("囲碁・将棋・クイズ");
                    picker3.Items.Add("ギャンブル");
                    picker3.Items.Add("美術");
                    picker3.Items.Add("工芸・工作");
                    picker3.Items.Add("茶道・香道・華道");
                    picker3.Items.Add("ミリタリー");
                    picker3.Items.Add("トレーディングカード");
                    picker3.Items.Add("その他");
                    picker3.Items.Add("自転車");
                    genreid = "00" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 9)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("恋愛");
                    picker3.Items.Add("妊娠・出産・子育て");
                    picker3.Items.Add("ペット");
                    picker3.Items.Add("住まい・インテリア");
                    picker3.Items.Add("ガーデニング・フラワー");
                    picker3.Items.Add("生活の知識");
                    picker3.Items.Add("占い");
                    picker3.Items.Add("冠婚葬祭・マナー");
                    picker3.Items.Add("手芸");
                    picker3.Items.Add("健康");
                    picker3.Items.Add("料理");
                    picker3.Items.Add("ドリンク・お酒");
                    picker3.Items.Add("生き方・リラクゼーション");
                    picker3.Items.Add("ファッション・美容");
                    picker3.Items.Add("その他");
                    picker3.Items.Add("雑貨");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 10)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("テレビ関連本");
                    picker3.Items.Add("映画");
                    picker3.Items.Add("音楽");
                    picker3.Items.Add("ゲーム");
                    picker3.Items.Add("演劇・舞踊");
                    picker3.Items.Add("演芸");
                    picker3.Items.Add("アニメーション");
                    picker3.Items.Add("フィギュア");
                    picker3.Items.Add("サブカルチャー");
                    picker3.Items.Add("その他");
                    picker3.Items.Add("タレント関連本");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 11)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("自然科学全般");
                    picker3.Items.Add("数学");
                    picker3.Items.Add("物理学");
                    picker3.Items.Add("化学");
                    picker3.Items.Add("地学・天文学");
                    picker3.Items.Add("生物学");
                    picker3.Items.Add("植物学");
                    picker3.Items.Add("動物学");
                    picker3.Items.Add("医学・薬学");
                    picker3.Items.Add("工学");
                    picker3.Items.Add("建築学");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 12)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("グラビアアイドル・タレント写真集");
                    picker3.Items.Add("その他");
                    picker3.Items.Add("動物・自然");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 13)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("資格・検定");
                    picker3.Items.Add("看護・医療関係資格");
                    picker3.Items.Add("法律関係資格");
                    picker3.Items.Add("ビジネス関係資格");
                    picker3.Items.Add("宅建・不動産関係資格");
                    picker3.Items.Add("食品・調理関係資格");
                    picker3.Items.Add("教育・心理関係資格");
                    picker3.Items.Add("インテリア関係資格");
                    picker3.Items.Add("介護・福祉関係資格");
                    picker3.Items.Add("技術・建築関係資格");
                    picker3.Items.Add("語学関係資格");
                    picker3.Items.Add("パソコン関係資格");
                    picker3.Items.Add("旅行主任者");
                    picker3.Items.Add("カラーコーディネーター・色彩検定");
                    picker3.Items.Add("数学検定");
                    picker3.Items.Add("公務員試験");
                    picker3.Items.Add("自動車免許");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();


                }
                if (this.picker2.SelectedIndex == 14)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("その他");
                    picker3.Items.Add("少年");
                    picker3.Items.Add("少女");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 15)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("楽譜");
                    picker3.Items.Add("ピアノ");
                    picker3.Items.Add("ギター");
                    picker3.Items.Add("管・打楽器");
                    picker3.Items.Add("吹奏楽・アンサンブル・ミニチュアスコア");
                    picker3.Items.Add("バイオリン・チェロ・コントラバス");
                    picker3.Items.Add("その他楽器");
                    picker3.Items.Add("LM（ライトミュージック）楽器教本");
                    picker3.Items.Add("バンドスコア");
                    picker3.Items.Add("合唱");
                    picker3.Items.Add("声楽");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 16)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("小説・エッセイ");
                    picker3.Items.Add("美容・暮らし・健康・料理");
                    picker3.Items.Add("ホビー・スポーツ・美術");
                    picker3.Items.Add("語学・学習参考書");
                    picker3.Items.Add("旅行・留学・アウトドア");
                    picker3.Items.Add("人文・思想・社会");
                    picker3.Items.Add("ビジネス・経済・就職");
                    picker3.Items.Add("パソコン・システム開発");
                    picker3.Items.Add("科学・医学・技術");
                    picker3.Items.Add("漫画（コミック）");
                    picker3.Items.Add("ライトノベル");
                    picker3.Items.Add("エンタメ");
                    picker3.Items.Add("写真集・タレント");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 17)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("小説・エッセイ");
                    picker3.Items.Add("美容・暮らし・健康・料理");
                    picker3.Items.Add("ホビー・スポーツ・美術");
                    picker3.Items.Add("絵本・児童書・図鑑");
                    picker3.Items.Add("語学・学習参考書");
                    picker3.Items.Add("旅行・留学・アウトドア");
                    picker3.Items.Add("人文・思想・社会");
                    picker3.Items.Add("ビジネス・経済・就職");
                    picker3.Items.Add("パソコン・システム開発");
                    picker3.Items.Add("科学・医学・技術");
                    picker3.Items.Add("エンタメ");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 18)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("小説");
                    picker3.Items.Add("コミック");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }

                if (this.picker2.SelectedIndex == 19)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("カレンダー");
                    picker3.Items.Add("手帳");
                    picker3.Items.Add("家計簿");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 20)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("筆記具");
                    picker3.Items.Add("筆記補助用品");
                    picker3.Items.Add("ノート");
                    picker3.Items.Add("学用品");
                    picker3.Items.Add("手紙・はがき・便箋");
                    picker3.Items.Add("手芸・書道・アート");
                    picker3.Items.Add("ブックカバー・しおり");
                    picker3.Items.Add("ファイル・収納用品");
                    picker3.Items.Add("事務・OA用品");
                    picker3.Items.Add("キャラクターグッズ");
                    picker3.Items.Add("デザイン文具");
                    picker3.Items.Add("シーズナル");
                    picker3.Items.Add("高級ステーショナリー");
                    picker3.Items.Add("その他");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                if (this.picker2.SelectedIndex == 21)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("基礎医学");
                    picker3.Items.Add("臨床医学一般");
                    picker3.Items.Add("臨床医学内科系");
                    picker3.Items.Add("臨床医学外科系");
                    picker3.Items.Add("臨床医学専門科別");
                    picker3.Items.Add("医学一般・社会医学");
                    picker3.Items.Add("基礎看護学");
                    picker3.Items.Add("臨床成人看護");
                    picker3.Items.Add("臨床看護専門科別");
                    picker3.Items.Add("臨床看護一般");
                    picker3.Items.Add("看護学生向け");
                    picker3.Items.Add("保健・助産");
                    picker3.Items.Add("医療関連科学・技術");
                    picker3.Items.Add("伝統医学・東洋医学");
                    picker3.Items.Add("薬学");
                    picker3.Items.Add("歯科医学");
                    picker3.Items.Add("試験対策(資格試験別)");
                    picker3.Items.Add("辞事典・白書・語学");
                    genreid = "0" + (picker2.SelectedIndex + 1).ToString();
                }
                genre2 = genreid;

            }
            catch (Exception e)
            {
                DisplayAlert("警告", e.ToString(), "OK");
            }
        }

        //21個
        private void OnSelectedIndexChanged2(object sender, EventArgs eventArgs)
        {
            try
            {

                if (picker3.SelectedIndex < 9)
                {
                    genreid = "";
                    genreid = genre2 + "00" + (picker3.SelectedIndex + 1).ToString();
                }
                else
                {
                    genreid = "";
                    genreid = genre2 + "0" + (picker3.SelectedIndex + 1).ToString();
                }

            }
            catch (Exception e)
            {
                DisplayAlert("警告", e.ToString(), "OK");
            }
        }

        //--------------------------------Serchボタンイベントハンドラ-----------------------------------
        private async void Serch(object sender, EventArgs e)
        {
            //2秒処理を待つ
            await Task.Delay(2000);
            items.Clear();
            var query = BookDB.select_all();
            var ListTitle = new List<String>();
            var ListReview = new List<double>();
            var ListValue = new List<string>();
            requestUrl = url + "&booksGenreId=001" + genreid; //URLにISBNコードを挿入

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

                JValue reviewAverageValue = (JValue)jobj["reviewAverage"];
                string reviewAverage = (string)reviewAverageValue.Value;
                double Review = double.Parse(reviewAverage);

                JValue titleKanaValue = (JValue)jobj["titleKana"];
                string titleKana = (string)titleKanaValue.Value;

                JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                string itemCaption = (string)itemCaptionValue.Value;

                JValue gazoValue = (JValue)jobj["largeImageUrl"];
                string gazo = (string)gazoValue.Value;

                ListTitle.Add(title);
                ListReview.Add(Review);

            };

            for (var j = 0; j < Items.Count; j++)
            {

                if (ListReview[j] <= 0.25)
                {
                    ListValue.Add("value_0_.png");
                }
                else if (ListReview[j] <= 0.75)
                {
                    ListValue.Add("value_0_5.png");
                }
                else if (ListReview[j] <= 1.25)
                {
                    ListValue.Add("value_1_.png");
                }
                else if (ListReview[j] <= 1.75)
                {
                    ListValue.Add("value_1_5.png");
                }
                else if (ListReview[j] <= 2.25)
                {
                    ListValue.Add("value_2_.png");
                }
                else if (ListReview[j] <= 2.75)
                {
                    ListValue.Add("value_2_5.png"); ;
                }
                else if (ListReview[j] <= 3.25)
                {
                    ListValue.Add("value_3_.png");
                }
                else if (ListReview[j] <= 3.75)
                {
                    ListValue.Add("value_3_5.png");
                }
                else if (ListReview[j] <= 4.25)
                {
                    ListValue.Add("value_4_.png");
                }
                else if (ListReview[j] <= 4.75)
                {
                    ListValue.Add("value_4_5.png");
                }
                else
                {
                    ListValue.Add("value_5_.png");
                }

                items.Add(new Book2 { Name = ListTitle[j], Value = ListReview[j], ValueImage = ListValue[j] });

            }


            RankListView.ItemsSource = items;


            //リフレッシュを止める
            this.RankListView.IsRefreshing = false;
        }

        //タイトルを入力して検索
        private async void Serch_title(object sender, EventArgs e)
        {
            string Title = title_bar.Text;


            //検索文字列を%EAとかの形に変える
            string encodedtitle = Uri.EscapeUriString(Title); //Systemアセンブリ中に存在 UTF-8のみ
            requestUrl = url + "&title=" + encodedtitle;

            //2秒処理を待つ
            //await Task.Delay(2000);
            items.Clear();
            var query = BookDB.select_all();
            var ListTitle = new List<String>();
            var ListReview = new List<double>();
            var ListValue = new List<string>();

            requestUrl = requestUrl + "&booksGenreId=001" + genreid;

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

            JValue countV = (JValue)json["hits"];
            string count = countV.Value.ToString();
            int getCount = int.Parse(count);

            var Items = JArray.Parse(json["Items"].ToString()); //Itemsは配列なのでJArrayにパース

            //結果を出力
            foreach (JObject jobj in Items)
            {
                //↓のように取り出す
                JValue titleValue = (JValue)jobj["title"];
                string title = (string)titleValue.Value;

                JValue reviewAverageValue = (JValue)jobj["reviewAverage"];
                string reviewAverage = (string)reviewAverageValue.Value;
                double Review = double.Parse(reviewAverage);

                JValue titleKanaValue = (JValue)jobj["titleKana"];
                string titleKana = (string)titleKanaValue.Value;

                JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                string itemCaption = (string)itemCaptionValue.Value;

                JValue gazoValue = (JValue)jobj["largeImageUrl"];
                string gazo = (string)gazoValue.Value;

                ListTitle.Add(title);
                ListReview.Add(Review);

            };


            for (var j = 0; j < Items.Count; j++)
            {

                if (ListReview[j] <= 0.25)
                {
                    ListValue.Add("value_0_.png");
                }
                else if (ListReview[j] <= 0.75)
                {
                    ListValue.Add("value_0_5.png");
                }
                else if (ListReview[j] <= 1.25)
                {
                    ListValue.Add("value_1_.png");
                }
                else if (ListReview[j] <= 1.75)
                {
                    ListValue.Add("value_1_5.png");
                }
                else if (ListReview[j] <= 2.25)
                {
                    ListValue.Add("value_2_.png");
                }
                else if (ListReview[j] <= 2.75)
                {
                    ListValue.Add("value_2_5.png"); ;
                }
                else if (ListReview[j] <= 3.25)
                {
                    ListValue.Add("value_3_.png");
                }
                else if (ListReview[j] <= 3.75)
                {
                    ListValue.Add("value_3_5.png");
                }
                else if (ListReview[j] <= 4.25)
                {
                    ListValue.Add("value_4_.png");
                }
                else if (ListReview[j] <= 4.75)
                {
                    ListValue.Add("value_4_5.png");
                }
                else
                {
                    ListValue.Add("value_5_.png");
                }

                items.Add(new Book2 { Name = ListTitle[j], Value = ListReview[j], ValueImage = ListValue[j] });

            }



            RankListView.ItemsSource = items;


            //リフレッシュを止める
            this.RankListView.IsRefreshing = false;
        }


        private async void OnRefreshing(object sender, EventArgs e)
        {
            //2秒処理を待つ
            await Task.Delay(2000);
            items.Clear();
            var ListTitle = new List<String>();
            var ListReview = new List<double>();
            var ListValue = new List<string>();

            requestUrl = url + "&booksGenreId=001" + genreid; //URLにISBNコードを挿入

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

                JValue reviewAverageValue = (JValue)jobj["reviewAverage"];
                string reviewAverage = (string)reviewAverageValue.Value;
                double Review = double.Parse(reviewAverage);

                JValue titleKanaValue = (JValue)jobj["titleKana"];
                string titleKana = (string)titleKanaValue.Value;

                JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                string itemCaption = (string)itemCaptionValue.Value;

                JValue gazoValue = (JValue)jobj["largeImageUrl"];
                string gazo = (string)gazoValue.Value;

                ListTitle.Add(title);
                ListReview.Add(Review);

            };

            for (var j = 0; j < Items.Count; j++)
            {

                if (ListReview[j] <= 0.25)
                {
                    ListValue.Add("value_0_.png");
                }
                else if (ListReview[j] <= 0.75)
                {
                    ListValue.Add("value_0_5.png");
                }
                else if (ListReview[j] <= 1.25)
                {
                    ListValue.Add("value_1_.png");
                }
                else if (ListReview[j] <= 1.75)
                {
                    ListValue.Add("value_1_5.png");
                }
                else if (ListReview[j] <= 2.25)
                {
                    ListValue.Add("value_2_.png");
                }
                else if (ListReview[j] <= 2.75)
                {
                    ListValue.Add("value_2_5.png"); ;
                }
                else if (ListReview[j] <= 3.25)
                {
                    ListValue.Add("value_3_.png");
                }
                else if (ListReview[j] <= 3.75)
                {
                    ListValue.Add("value_3_5.png");
                }
                else if (ListReview[j] <= 4.25)
                {
                    ListValue.Add("value_4_.png");
                }
                else if (ListReview[j] <= 4.75)
                {
                    ListValue.Add("value_4_5_.png");
                }
                else
                {
                    ListValue.Add("value_5_.png");
                }

                items.Add(new Book2 { Name = ListTitle[j], Value = ListReview[j], ValueImage = ListValue[j] });

            }

            RankListView.ItemsSource = items;

            //リフレッシュを止める
            this.RankListView.IsRefreshing = false;
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