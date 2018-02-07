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
    public partial class SeekDetailPage : ContentPage
    {
        string ValueImage;
        string URL;


        public SeekDetailPage(string Name,string author,string Date,string publisher, string itemcaption,double value,string valueimage,string ImageUrl)
        {
            InitializeComponent();
        
            title2.Text = Name;
            Auther2.Text = "著者名：" + author;
            SalesDate2.Text = "発売日：" + Date;
            Publisher2.Text = "出版社：" + publisher;
            ItemCaption2.Text = "説明：" + itemcaption;
            Review.Text = value.ToString();
            ValueImage = valueimage;
            URL = ImageUrl;
            


        }

    }

}

