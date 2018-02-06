using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace book3
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {

            InitializeComponent();

            string _device = Device.Idiom.ToString();

            if (_device == "Phone")
            {
                this.Children.Add(new NavigationPage(new AndroidBookPage()) { Icon = "bookmark_24.png", Title = "本棚" });
            }
            else
            {
                this.Children.Add(new NavigationPage(new BookPage()) { Icon = "bookmark_24.png", Title = "本棚" });
            }

            this.Children.Add(new NavigationPage(new CameraPage()) { Icon = "camera_24.png", Title = "カメラ" });

            if (_device == "Phone")
            {
                this.Children.Add(new NavigationPage(new AndroidSeekPage()) { Icon = "star_32.png", Title = "さがす" });
            }
            else
            {
                this.Children.Add(new NavigationPage(new SeekPage()) { Icon = "star_32.png", Title = "さがす" });
            }

            this.Children.Add(new NavigationPage(new PropertyPage()) { Icon = "gear_24.png", Title = "設定" });


        }
    }
}
