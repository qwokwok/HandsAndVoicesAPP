using HandsAndVoices.Views.Nav;
using System;
using Xamarin.Forms;
using HandsAndVoices.Server;
using HandsAndVoices.Models;
using System.Collections.Generic;
using Xamarin.Essentials;
using HandsAndVoices.Themes;

[assembly: ExportFont("Ubuntu-Medium.ttf", Alias = "Ubuntu")]
namespace HandsAndVoices
{
    public partial class App : Application
    {
        //static ArticleRepository database;
        //public static ArticleRepository Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new ArticleRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "article.db3"));
        //        }
        //        return database;
        //    }
        //}

        public static DateTime FirstTime { get; set; }
        public static int DayCount { get; set; }
        public static List<Advice> Advices { get; set; } = Website.Advices;
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
            var isDark = Preferences.Get("theme_key", false);

            if(isDark)
                Application.Current.Resources.MergedDictionaries.Add(new Dark());
            else
                Application.Current.Resources.MergedDictionaries.Add(new Light());
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
