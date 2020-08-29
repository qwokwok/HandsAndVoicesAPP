using HandsAndVoices.Models;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Quote;
using HandsAndVoices.Views.Resource;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class SectionViewModel : BasicViewModel
    {
        #region Properties
        public INavigation Navigation { get; set; }
        public List<Advice> ArticleList
        {
            get => App.Advices;
            set
            {
                App.Advices = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public Command PushCommand { get; set; }
        #endregion

        public SectionViewModel()
        {
            PushCommand = new Command<Advice>(PushAsync);
        }

        void PushAsync(Advice item)
        {
            App.Selected = item;

            if (item.Day != 0)
            {
                if (App.Section == "Article") Navigation.PushAsync(new ArticleDetailPage());
                if (App.Section == "Quote") Navigation.PushAsync(new QuoteDetailPage());
                if (App.Section == "Resource") Navigation.PushAsync(new ResourceDetailPage());
            }
        }
    }
}
