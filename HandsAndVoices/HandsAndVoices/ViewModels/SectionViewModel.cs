using HandsAndVoices.Models;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Nav;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class SectionViewModel : BasicViewModel
    {
        #region Fields
        private List<Example> articleList;
        #endregion

        #region Properties
        public INavigation Navigation { get; set; }
        public List<Example> ArticleList
        {
            get => articleList;
            set
            {
                articleList = value;
                NotifyPropertyChanged();
            }
        }

        public string Title
        {
            get => MainMasterPage.Title;
            set
            {
                MainMasterPage.Title = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public Command PushCommand { get; set; }
        #endregion

        public SectionViewModel()
        {
            PushCommand = new Command<Example>(PushAsync);

            // sample list
            articleList = new List<Example>();
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
        }

        void PushAsync(Example item)
        {
            PushCommand = new Command<Example>(PushAsync);
            Navigation.PushAsync(new ArticleDetailPage(item));
        }
    }
}
