using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using book3.Droid;

[assembly: Dependency(typeof(DeviceService))]
namespace book3.Droid
{
    public class DeviceService : IDeviceService
    {
        public void PlayVibrate()
        {
            var obj = Forms.Context.GetSystemService(Context.VibratorService);
            Vibrator vibrator = (Vibrator)obj;
            vibrator.Vibrate(500);
        }
    }
}