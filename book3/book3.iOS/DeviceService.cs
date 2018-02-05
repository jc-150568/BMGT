using AudioToolbox;
using Xamarin.Forms;
using book3.iOS.Services;
[assembly: Dependency(typeof(DeviceService))]
namespace book3.iOS.Services
{
    public class DeviceService : IDeviceService
    {
        public void PlayVibrate()
        {
            SystemSound.Vibrate.PlayAlertSound();
        }
    }
}