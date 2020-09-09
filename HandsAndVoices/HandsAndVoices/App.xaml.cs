using HandsAndVoices.Views.Nav;
using System;
using Xamarin.Forms;
using HandsAndVoices.Models;
using System.Collections.Generic;
using Xamarin.Essentials;
using HandsAndVoices.Themes;
using HandsAndVoices.Services;

[assembly: ExportFont("Ubuntu-Medium.ttf", Alias = "Ubuntu")]
namespace HandsAndVoices
{
    public partial class App : Application
    {
        public static DateTime FirstTime { get; set; }
        public static int DayCount { get; set; }
        public static List<Advice> Advices { get; set; } = ReadJson.Advices;
        public static string Section { get; set; }
        public static Advice Selected { get; set; }

        public App()
        {
            InitializeComponent();

            // Initializing our MasterDetailPage which contains our drawer and action bar.
            MainPage = new MainMasterPage();
        }

        protected override void OnStart()
        {
            //string theme = Preferences.Get("o_key", "dark");

            //switch(theme)
            //{
            //    case "blue": Application.Current.Resources.MergedDictionaries.Add(new Blue()); break;
            //    case "dark": Application.Current.Resources.MergedDictionaries.Add(new Dark()); break;
            //    case "light": Application.Current.Resources.MergedDictionaries.Add(new Light()); break;
            //}

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
