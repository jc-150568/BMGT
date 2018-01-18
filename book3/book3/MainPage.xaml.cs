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
            try
            {
            InitializeComponent();
            }
            catch (Exception e)
            {

                DisplayAlert("error", e.ToString(), "OK");
            }
        }
    }
}
