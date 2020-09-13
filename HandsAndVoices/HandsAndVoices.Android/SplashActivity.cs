using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace HandsAndVoices.Droid
{
    [Activity(Label = "Hands and Voices", Icon = "@mipmap/icon", MainLauncher = true, NoHistory = true, Theme = "@style/SplashTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Splash);
            Thread.Sleep(1000);

            StartActivity(typeof(MainActivity));

            Finish();
        }
    }
}