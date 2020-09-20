using System;
using Xamarin.Forms;
using HandsAndVoices.Models;
using System.Collections.Generic;
using HandsAndVoices.Themes;
using HandsAndVoices.Services;
using HandsAndVoices.Views.Nav;

[assembly: ExportFont("Ubuntu-Medium.ttf", Alias = "Ubuntu")]
namespace HandsAndVoices
{
    public partial class App : Application
    {
        public static DateTime FirstTime { get; set; }
        public static int DayCount { get; set; }
        public static List<Advice> Advices { get; set; } = ReadJson.Advices;
        public static List<Advice> ReseveredAdvices { get; set; } = ReadJson.ReservedAdvices;
        public static string Section { get; set; }
        public static Advice Selected { get; set; }

        public App()
        {
            InitializeComponent();

            // Initializing our MasterDetailPage which contains our drawer and action bar.
            if (Device.RuntimePlatform == Device.Android)
            {
                //MainPage = new MainMasterPage();
                MainPage = new TransparentNavigationPage(new MainTabbedPage()) { BarTextColor = Color.White };
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new TransparentNavigationPage(new MainTabbedPage()) { BarTextColor = Color.White };
            }
        }

        protected override void OnStart()
        {
            var appinfo = App.Current.RequestedTheme;
            if(OSAppTheme.Light == appinfo)
                Application.Current.Resources.MergedDictionaries.Add(new Light());

            else
                Application.Current.Resources.MergedDictionaries.Add(new Blue());

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
