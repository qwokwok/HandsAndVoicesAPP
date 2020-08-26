using HandsAndVoices.Views.Nav;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Initializing our MasterDetailPage which contains our drawer and action bar.
            MainPage = new MainMasterPage();
        }

        protected override void OnStart()
        {
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
