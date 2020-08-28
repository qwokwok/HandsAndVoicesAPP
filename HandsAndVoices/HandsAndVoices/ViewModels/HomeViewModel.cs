using HandsAndVoices.Models;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Quote;
using HandsAndVoices.Views.Resource;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class HomeViewModel : BasicViewModel
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
        public Command ArticleCommand { get; set; }
        public Command QuoteCommand { get; set; }
        public Command ResourceCommand { get; set; }
        #endregion

        #region Constructors
        public HomeViewModel()
        {
            ArticleCommand = new Command<Advice>(PushArticleAsync);
            QuoteCommand = new Command<Advice>(PushQuoteAsync);
            ResourceCommand = new Command<Advice>(PushResourceAsync);
        }
        #endregion

        #region Methods
        void PushArticleAsync(Advice item)
        {
            PushToDetail(item, "Article");
        }

        void PushQuoteAsync(Advice item)
        {
            PushToDetail(item, "Quote");
        }

        void PushResourceAsync(Advice item)
        {
            PushToDetail(item, "Resource");
        }
        
        void PushToDetail(Advice item, string section)
        {
            if (item.Day != 0)
            {
                App.Selected = item;
                App.Section = section;

                switch(section)
                {
                    case "Article": Navigation.PushAsync(new ArticleDetailPage(item)); break;
                    case "Quote": Navigation.PushAsync(new QuoteDetailPage(item)); break;
                    case "Resource": Navigation.PushAsync(new ResourceDetailPage(item)); break;
                }
            }
        }
        #endregion
    }
}
