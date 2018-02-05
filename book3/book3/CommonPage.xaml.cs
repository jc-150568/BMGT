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
        int hoge = 0;

        public CommonPage()
        {
            InitializeComponent();
            
            List<Manage> hoge2;

            hoge2 = Manage._camera();
            if (hoge2 == null)
            {
                Manage.insertCamera();
                hoge2 = Manage._camera();
            }
            
            foreach(var x in hoge2)
            {
                hoge = x.camera_bool;
            }
            if(hoge == 0)
            {
                this.sw2.On = false;
                Manage.camera2();
                
            }
            else
            {
                this.sw2.On = true;
                Manage.camera();
            }
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

        private void Onbutton2(object sender, EventArgs e)
        {
            if (sw2.On == true)
            {
                Manage.camera();
            }
            else if (sw2.On == false)
            {
                Manage.camera2();
            }
        }
    }
}