using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using HandsAndVoices.Droid.Services;

namespace HandsAndVoices.Droid
{
    [Activity(Label = "Hands and Voices", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var config = new FFImageLoading.Config.Configuration
            {
                ExecuteCallbacksOnUIThread = false,
            };
            FFImageLoading.ImageService.Instance.Initialize(config);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            var intent = new Intent(this, typeof(PeriodicService));
            StartService(intent);

            //var alarmIntent = new Intent(this, typeof(AlarmReceiver));
            //alarmIntent.PutExtra("title", "Hello");
            //alarmIntent.PutExtra("message", "World!");

            //var pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

            //var alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();

            //alarmManager.SetRepeating(
            //    AlarmType.ElapsedRealtime,
            //    SystemClock.ElapsedRealtime() + 60 * 1000,
            //    SystemClock.ElapsedRealtime() + 5 * 1000, 
            //    pending);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}