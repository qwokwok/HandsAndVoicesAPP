using HandsAndVoices.Views.Nav;
using System;
using Xamarin.Forms;
using Xamarin.Essentials;

[assembly: ExportFont("Ubuntu-Medium.ttf", Alias = "Ubuntu")]
namespace HandsAndVoices
{
    public partial class App : Application
    {
        public DateTime FirstTime { get; set; }
        public App()
        {
            InitializeComponent();

            // Initializing our MasterDetailPage which contains our drawer and action bar.
            MainPage = new MainMasterPage();
        }

        protected override void OnStart()
        {
            // if a value is null, it will return true
            var isFirstTime = Preferences.Get("isFirst_key", true);
            if(isFirstTime)
            {
                // stores date of first time using the app
                Preferences.Set("isFirst_key", false);
                var date = DateTime.Today;
                Preferences.Set("date_key", date);
                FirstTime = date;
            }
            else
            {
                FirstTime = Preferences.Get("date_key", DateTime.Parse("1/1/2000"));
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /// <summary>
        ///     Contains keys for App.xaml resourceDictionary.
        /// </summary>
        public readonly struct ResourceKeys
        {
            public const string GRADIENT_BLUE = "GradientBlue";
            public const string GRADIENT_ORAN = "GradientOran";
        }

        
    }
}
