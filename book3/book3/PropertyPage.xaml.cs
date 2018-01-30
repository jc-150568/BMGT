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
    public partial class PropertyPage : ContentPage
    {
        public PropertyPage()
        {
            InitializeComponent();
        }
        
        private void Common(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CommonPage());
        }
        private void Backup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BackupPage());
        }
        private void Help(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }
        private async Task bomb(object sender, EventArgs e)
        {
            bool x = await DisplayAlert("警告", "本棚を全削除します。\n\rよろしいですか？", "OK", "CANCEL");
            if (x == true)
            {
                BookDB.dropBook();
            }
        }


    }
}