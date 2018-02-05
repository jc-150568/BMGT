using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public ObservableCollection<Book> items = new ObservableCollection<Book>();
        public int sortkey = 0;
        public string terms = "error";

        public BookPage()
        {
            InitializeComponent();

            if (BookDB.select_all() != null)
            {
                var query = BookDB.select_all();
                var titleList = new List<String>();
                var isbnList = new List<String>();
                var RedList = new List<int>();
                var BlueList = new List<int>();
                var RedList2 = new List<string>();
                var BlueList2 = new List<string>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    titleList.Add(user.Title);
                    isbnList.Add(user.ISBN);
                    RedList.Add(user.RedStar);
                    BlueList.Add(user.BlueBook);
                }
                for (var h = 0; h < query.Count; h++)
                {
                    if (RedList[h] == 1)
                    {
                        RedList2.Add("red_star_72.png");
                    }
                    else
                    {
                        RedList2.Add("");
                    }

                    if (BlueList[h] == 1)
                    {
                        BlueList2.Add("blue_book_72.png");
                    }
                    else
                    {
                        BlueList2.Add("");
                    }
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book
                    {
                        Name = titleList[j],
                        ISBN = isbnList[j],
                        RedStar = RedList[j],
                        BlueBook = BlueList[j],
                        RedStar2 = RedList2[j],
                        BlueBook2 = BlueList2[j]
                    });

                }
            }
            else
            {
                items.Add(new Book { Name = "表示するものがありません" });
            }



            BookListView.ItemsSource = items;

        }


        public class Book
        {
            public string ISBN { get; set; }

            public string Name { get; set; }

            public int RedStar { get; set; }

            public string RedStar2 { get; set; }

            public int BlueBook { get; set; }

            public string BlueBook2 { get; set; }

        }
        
        private void OnItemSelected(object sender, ItemTappedEventArgs e)
        {

            string _device = Device.Idiom.ToString();

            Book book = (Book)BookListView.SelectedItem;
            string isbn = book.ISBN;
            /*
            if (_device == "Phone")
            {
                Navigation.PushAsync(new DetailPage2(isbn));
            }
            else
            {
                Navigation.PushAsync(new DetailPage(isbn));
            }
            */
            Navigation.PushAsync(new DetailPage2(isbn));

        }

        /// <summary>
        /// リフレッシュ時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnRefreshing(object sender, EventArgs e)
        {
            //2秒処理を待つ
            await Task.Delay(2000);
            items.Clear();

            if (BookDB.select_all() != null)
            {
                var query = BookDB.select_all();
                var titleList = new List<String>();
                var isbnList = new List<String>();
                var RedList = new List<int>();
                var BlueList = new List<int>();
                var RedList2 = new List<string>();
                var BlueList2 = new List<string>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    titleList.Add(user.Title);
                    isbnList.Add(user.ISBN);
                    RedList.Add(user.RedStar);
                    BlueList.Add(user.BlueBook);
                }
                for (var h = 0; h < query.Count; h++)
                {
                    if (RedList[h] == 1)
                    {
                        RedList2.Add("red_star_72.png");
                    }
                    else
                    {
                        RedList2.Add("");
                    }

                    if (BlueList[h] == 1)
                    {
                        BlueList2.Add("blue_book_72.png");
                    }
                    else
                    {
                        BlueList2.Add("");
                    }
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book
                    {
                        Name = titleList[j],
                        ISBN = isbnList[j],
                        RedStar = RedList[j],
                        BlueBook = BlueList[j],
                        RedStar2 = RedList2[j],
                        BlueBook2 = BlueList2[j]
                    });

                }
            }
            else
            {
                items.Add(new Book { Name = "表示するものがありません" });
            }



            BookListView.ItemsSource = items;


            //リフレッシュを止める
            this.BookListView.IsRefreshing = false;
        }


        private async void picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (picker.SelectedIndex == 0)
            {
                terms = "TitleKana";
                sortkey = 1;
            }
            else if (picker.SelectedIndex == 1)
            {
                terms = "TitleKana";
                sortkey = 2;
            }
            else if (picker.SelectedIndex == 2)
            {
                terms = "AuthorKana";
                sortkey = 1;
            }
            else if (picker.SelectedIndex == 3)
            {
                terms = "AuthorKana";
                sortkey = 2;
            }
            else if (picker.SelectedIndex == 4)
            {
                terms = "SalesDate";
                sortkey = 1;
            }
            else if (picker.SelectedIndex == 5)
            {
                terms = "SalesDate";
                sortkey = 2;
            }
            else if (picker.SelectedIndex == 6)
            {
                terms = "Date";
                sortkey = 1;
            }
            else if (picker.SelectedIndex == 7)
            {
                terms = "Date";
                sortkey = 2;
            }

        }

        private async void OnSortButtonClicked(object sender, EventArgs e)
        {
            //2秒処理を待つ
            await Task.Delay(2000);
            items.Clear();

            if (BookDB.sortselectBook(terms, sortkey) != null)
            {
                var query = BookDB.sortselectBook(terms, sortkey);
                var titleList = new List<String>();
                var isbnList = new List<String>();
                var RedList = new List<int>();
                var BlueList = new List<int>();
                var RedList2 = new List<string>();
                var BlueList2 = new List<string>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    titleList.Add(user.Title);
                    isbnList.Add(user.ISBN);
                    RedList.Add(user.RedStar);
                    BlueList.Add(user.BlueBook);
                }
                for (var h = 0; h < query.Count; h++)
                {
                    if (RedList[h] == 1)
                    {
                        RedList2.Add("red_star_72.png");
                    }
                    else
                    {
                        RedList2.Add("");
                    }

                    if (BlueList[h] == 1)
                    {
                        BlueList2.Add("blue_book_72.png");
                    }
                    else
                    {
                        BlueList2.Add("");
                    }
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book
                    {
                        Name = titleList[j],
                        ISBN = isbnList[j],
                        RedStar = RedList[j],
                        BlueBook = BlueList[j],
                        RedStar2 = RedList2[j],
                        BlueBook2 = BlueList2[j]
                    });

                }
            }
            else
            {
                items.Add(new Book { Name = "表示するものがありません" });
            }

            BookListView.ItemsSource = items;

            //リフレッシュを止める
            this.BookListView.IsRefreshing = false;
        }

        //サーチイベントハンドラ
        private async void Search_title(object sender, EventArgs e)
        {
            string keyword = sBar.Text.ToString();
            items.Clear();
            if (keyword != null)
            {
                if (BookDB.selectBook_search(keyword) != null)
                {
                    var query = BookDB.selectBook_search(keyword);
                    var titleList = new List<String>();
                    var isbnList = new List<String>();
                    var RedList = new List<int>();
                    var BlueList = new List<int>();
                    var RedList2 = new List<string>();
                    var BlueList2 = new List<string>();
                    //*をリストにぶち込んで個数分addするのでもいいのでは
                    foreach (var user in query)
                    {
                        titleList.Add(user.Title);
                        isbnList.Add(user.ISBN);
                        RedList.Add(user.RedStar);
                        BlueList.Add(user.BlueBook);
                    }
                    for (var h = 0; h < query.Count; h++)
                    {
                        if (RedList[h] == 1)
                        {
                            RedList2.Add("red_star_72.png");
                        }
                        else
                        {
                            RedList2.Add("");
                        }

                        if (BlueList[h] == 1)
                        {
                            BlueList2.Add("blue_book_72.png");
                        }
                        else
                        {
                            BlueList2.Add("");
                        }
                    }
                    for (var j = 0; j < query.Count; j++)
                    {
                        items.Add(new Book
                        {
                            Name = titleList[j],
                            ISBN = isbnList[j],
                            RedStar = RedList[j],
                            BlueBook = BlueList[j],
                            RedStar2 = RedList2[j],
                            BlueBook2 = BlueList2[j]
                        });

                    }
                }
                else
                {
                    await DisplayAlert("ERROR!", "Not Found", "OK");
                }


                BookListView.ItemsSource = items;

                //リフレッシュを止める
                this.BookListView.IsRefreshing = false;

            }
        }

    }
}
