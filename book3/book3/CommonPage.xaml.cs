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

        private void Onbutton(object sender, EventArgs e)
        {
            if(sw.On == true)
            {
                DisplayAlert("Alert", "オンになった", "OK");
            }
            else if (sw.On == false)
            {
                DisplayAlert("Alert", "オフになった", "OK");
            }
        }
    }
}