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
    public partial class SeekPage : ContentPage
    {
        public SeekPage()
        {
            InitializeComponent();
        }
        // 親カテゴリのプルダウンに応じて子カテゴリの内容を変更する
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            try
            {

                if (this.picker2.SelectedIndex == 0)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("Baboon");
                    picker3.Items.Add("Capuchin Monkey");
                    picker3.Items.Add("Blue Monkey");
                    picker3.Items.Add("Squirrel Monkey");
                    picker3.Items.Add("Golden Lion Tamarin");
                    picker3.Items.Add("Howler Monkey");
                    picker3.Items.Add("Japanese Macaque");
                }

                if (this.picker2.SelectedIndex == 1)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("セント");
                    picker3.Items.Add("ビント");
                    picker3.Items.Add("ティーヴィー");
                    picker3.Items.Add("Squirrel Monkey");
                    picker3.Items.Add("Golden Lion Tamarin");
                    picker3.Items.Add("Howler Monkey");
                    picker3.Items.Add("Japanese Macaque");
                }
            }
            catch (Exception e)
            {
                DisplayAlert("警告", e.ToString(), "OK");
            }
        }
    }
}