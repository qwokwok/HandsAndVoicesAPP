using HandsAndVoices.Models;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Quote;
using HandsAndVoices.Views.Resource;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class ExploreViewModel : BasicViewModel
    {
        #region Fields
        private double isArticleExplored;
        private double isParentExplored;
        private double isDhhExplored;
        private double isResourceExplored;
        #endregion

        #region Properties
        public INavigation Navigation { get; set; }
        public double IsArticleExplored 
        {
            get => CheckIsExplored("article_key");
            set
            {
                isArticleExplored = value;
                NotifyPropertyChanged();
            }
        }
        public double IsParentExplored 
        {
            get => CheckIsExplored("parent_key");
            set
            {
                isParentExplored = value;
                NotifyPropertyChanged();
            }
        }
        public double IsDhhExplored
        {
            get => CheckIsExplored("dhh_key");
            set
            {
                isDhhExplored = value;
                NotifyPropertyChanged();
            }
        }
        public double IsResourceExplored 
        {
            get => CheckIsExplored("resource_key");
            set
            {
                isResourceExplored = value;
                NotifyPropertyChanged();
            }
        }

        public Advice Article
        {
            get => App.ReseveredAdvices[0];
            set
            {
                App.ReseveredAdvices[0] = value;
                NotifyPropertyChanged();
            }
        }
        #endregion 

        #region Commands
        public Command ArticleCommand { get; set; }
        public Command ParentQuoteCommand { get; set; }
        public Command DHHQuoteCommand { get; set; }
        public Command ResourceCommand { get; set; }
        public ICommand FinishCommand => new Command(() =>
        {
            Navigation.PopModalAsync();
        });
        #endregion

        public ExploreViewModel()
        {
            App.Selected = Article;
            ArticleCommand = new Command(PushArticle);
            ParentQuoteCommand = new Command(PushParentQuote);
            DHHQuoteCommand = new Command(PushDHHQuote);
            ResourceCommand = new Command(PushResource);
        }

        #region Methods
        public void PushArticle()
        {
            PushSpecificPage("Article", "article_key");
        }

        void PushParentQuote()
        {
            PushSpecificPage("Parent", "parent_key");
        }

        void PushDHHQuote()
        {
            PushSpecificPage("DHH", "dhh_key");
        }

        void PushResource()
        {
            PushSpecificPage("Resource", "resource_key");
        }

        double CheckIsExplored(string key)
        {
            if (Preferences.Get(key, false))
                return 0;

            else
                return 50;
        }

        void PushSpecificPage(string section, string key)
        {
            App.Section = section;
            Preferences.Set(key, true);

            switch(section)
            {
                case "Article": Navigation.PushAsync(new ArticleDetailPage()); break;
                case "Parent": Navigation.PushAsync(new QuoteDetailPage()); break;
                case "DHH": Navigation.PushAsync(new DHHDetailPage()); break;
                case "Resource": Navigation.PushAsync(new ResourceDetailPage()); break;
            }
        }
        #endregion
    }
}
