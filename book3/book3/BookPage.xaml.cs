using System;
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
        public BookPage()
        {
            InitializeComponent();

            var query = BookDB.select_title_count();

            var query2 = BookDB.select_title();

            ObservableCollection<Book> items = new ObservableCollection<Book>();
            var List1 = new List<String>();

            foreach (var user in query2)
            {
                List1.Add(user.Title);
            }
            for (var j = 0; j < query2.Count; j++)
            {
                items.Add(new Book { Name = List1[j], /*Value = 2.5*/ });

            }

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Value <= 0.25)
                {
                    items[i].ValueImage = "value_0.png";
                }

                else if (items[i].Value <= 0.75)
                {
                    items[i].ValueImage = "value_0.5.png";
                }

                else if (items[i].Value <= 1.25)
                {
                    items[i].ValueImage = "value_1.png";
                }

                else if (items[i].Value <= 1.75)
                {
                    items[i].ValueImage = "value_1.5.png";
                }

                else if (items[i].Value <= 2.25)
                {
                    items[i].ValueImage = "value_2.png";
                }

                else if (items[i].Value <= 2.75)
                {
                    items[i].ValueImage = "value_2.5.png";
                }

                else if (items[i].Value <= 3.25)
                {
                    items[i].ValueImage = "value_3.png";
                }

                else if (items[i].Value <= 3.75)
                {
                    items[i].ValueImage = "value_3.5.png";
                }

                else if (items[i].Value <= 4.25)
                {
                    items[i].ValueImage = "value_4.png";
                }

                else if (items[i].Value <= 4.75)
                {
                    items[i].ValueImage = "value_4.5.png";
                }

                else
                {
                    items[i].ValueImage = "value_5.png";
                }


                if (items[i].RedStar == true)
                {
                    items[i].RedStar2 = "red_star_72.png";
                }

                if (items[i].BlueBook == true)
                {
                    items[i].BlueBook2 = "blue_book_72.png";
                }

            }

            BookListView.ItemsSource = items;

        }


        public class Book
        {
            public int ISBN { get; set; }

            public string Name { get; set; }

            public double Value { get; set; }

            public string ValueImage { get; set; }

            public bool RedStar { get; set; }

            public string RedStar2 { get; set; }

            public bool BlueBook { get; set; }

            public string BlueBook2 { get; set; }

        }


    }
}
