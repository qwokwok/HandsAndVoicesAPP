using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using HandsAndVoices.Server;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices
{
    public partial class App : Application
    {

        private static ArticleRepository _database;

        public static ArticleRepository Database => _database ??= new ArticleRepository(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Hand_Voice_Database.hvdb"));

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Push Notification Dependency
            // AppCenter.Start("Enter thr String ID from App Center", typeof(Push));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
