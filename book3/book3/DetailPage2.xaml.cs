using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage2 : ContentPage
    {
        // ボタンとスイッチの判定
        string Isbn;
        string title;
        string Date;
        string type;
        string itemcaption;
        string author;
        string publisher;

        int read;
        int redstar;
        int bluebook;


        public DetailPage2(string isbn)
        {
            InitializeComponent();
            //var query = BookDB.selectUserISBN(this.Isbn);

            Isbn = isbn;
            if (BookDB.select_isbn(isbn) != null)
            {
                var query = BookDB.select_isbn(isbn);

                foreach (var book in query)
                {
                    title = book.Title;
                    bluebook = book.BlueBook;
                    redstar = book.RedStar;
                    read = book.Read;
                    author = book.Author;
                    Date = book.SalesDate;
                    type = book.Type;
                    publisher = book.Publisher;
                    itemcaption = book.ItemCaption;
                }
            }
            else
            {
                DisplayAlert("表なし", "表なし", "OK");
            }
            title2.Text = title;
            Type2.Text = "タイプ：" + type;
            SalesDate2.Text = "発売日:" + Date;
            Publisher2.Text = "出版社:" + publisher;
            ItemCaption2.Text = "説明:" + itemcaption;

            if (bluebook == 1)
            {
                this.image1.Image = "blue_book_24.png";
            }

            else
            {
                this.image1.Image = "gray_book_24.png";
            }

            if (redstar == 1)
            {
                this.image2.Image = "red_star_24.png";
            }

            else
            {
                this.image2.Image = "gray_star_24.png";
            }

            if (read == 0)
            {
                this.unread2.Text = "未読";
                unread1.IsToggled = false;
            }

            if (read == 1)
            {
                this.unread2.Text = "既読";
                unread1.IsToggled = true;
            }
        }


        // 読みたいボタンを点滅させる
        private void OnImageClicked1(object sender, EventArgs e)
        {
            if (bluebook == 1)
            {
                BookDB.Gray_Book(Isbn);
                this.image1.Image = "gray_book_24.png";
                bluebook = 0;
            }

            else
            {
                BookDB.Blue_Book(Isbn);
                this.image1.Image = "blue_book_24.png";
                bluebook = 1;
            }
        }

        // お気にいりボタンを点滅させる
        private void OnImageClicked2(object sender, EventArgs e)
        {
            if (redstar == 1)
            {
                BookDB.Gray_Star(Isbn);
                this.image2.Image = "gray_star_24.png";
                redstar = 0;
            }

            else
            {
                BookDB.Red_Star(Isbn);
                this.image2.Image = "red_star_24.png";
                redstar = 1;
            }
        }

        // ラベルを未読⇔既読にする
        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if (unread1.IsToggled == true)
            {
                BookDB.ReadBook(Isbn);
                this.unread2.Text = "既読";
            }
            if (unread1.IsToggled == false)
            {
                BookDB.UnreadBook(Isbn);
                this.unread2.Text = "未読";
            }
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool x = await DisplayAlert("警告", "削除してもよろしいですか？", "はい", "いいえ");
            if (x == true)
            {
                BookDB.deleteBook(Isbn);
                Navigation.PushAsync(new BookPage());
            }
        }
    }
}