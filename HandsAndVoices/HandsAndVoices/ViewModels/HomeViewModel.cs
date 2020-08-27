﻿using HandsAndVoices.Models;
using HandsAndVoices.Views.Article;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class HomeViewModel : BasicViewModel
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
        #endregion

        #region Commands
        public Command ChangedCommand { get; set; }
        #endregion

        #region Constructors
        public HomeViewModel()
        {
            ChangedCommand = new Command<Example>(PushAsync);

            // sample list
            articleList = new List<Example>();
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
        }
        #endregion

        #region Methods
        void PushAsync(Example item)
        {
            Navigation.PushAsync(new ArticleDetailPage(item));
        }
        #endregion
    }
}
