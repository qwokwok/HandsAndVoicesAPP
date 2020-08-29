using HandsAndVoices.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class DetailViewModel : BasicViewModel
    {
        public Advice Advice
        {
            get => App.Selected;
            set { App.Selected = value; NotifyPropertyChanged(); }
        }

        public ICommand LinkCommand => new Command(async () =>
        {
            if (App.Section == "Article") await OpenBrowser(new Uri(Advice.Link));
            if (App.Section == "Resource") await OpenBrowser(Advice.ResourceLink);
        });

        public DetailViewModel()
        {

        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
