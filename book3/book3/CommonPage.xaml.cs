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
    public partial class CommonPage : ContentPage
    {
        public CommonPage()
        {
            InitializeComponent();
        }

        private void On1(object sender, EventArgs e)
        {
            DisplayAlert("おんちぇんじ", "やったー", "くそ");
        }
    }
}