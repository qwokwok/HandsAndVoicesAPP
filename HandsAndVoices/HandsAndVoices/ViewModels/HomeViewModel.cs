﻿using HandsAndVoices.Models;
using HandsAndVoices.Services;
using HandsAndVoices.Themes;
using HandsAndVoices.Views;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Quote;
using HandsAndVoices.Views.Resource;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
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

        #region Events
        public event Action UpdateSkiaColor;
        #endregion

        #region Commands
        public Command ArticleCommand { get; set; }
        public Command ParentQuoteCommand { get; set; }
        public Command DHHQuoteCommand { get; set; }
        public Command ResourceCommand { get; set; }
        public ICommand TopicCommand => new Command(() =>
        {
            Navigation.PushAsync(new TopicPage());
        });

        public ICommand BlueCommand => new Command(() =>
        {
            ChangeTheme("blue", new Blue());
        });

        public ICommand LightCommand => new Command(() =>
        {
            ChangeTheme("light", new Light());
        });

        public ICommand DarkCommand => new Command(() =>
        {
            ChangeTheme("dark", new Dark());
        });
        #endregion

        #region Constructors
        public HomeViewModel()
        {
            ArticleCommand = new Command<Advice>(PushArticle);
            ParentQuoteCommand = new Command<Advice>(PushParentQuote);
            DHHQuoteCommand = new Command<Advice>(PushDHHQuote);
            ResourceCommand = new Command<Advice>(PushResource);
        }
        #endregion

        #region Methods
        void PushArticle(Advice item)
        {
            PushToDetail(item, "Article");
        }

        void PushParentQuote(Advice item)
        {
            PushToDetail(item, "Parent");
        }

        void PushDHHQuote(Advice item)
        {
            PushToDetail(item, "DHH");
        }

        void PushResource(Advice item)
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
                    case "Article": Navigation.PushAsync(new ArticleDetailPage()); break;
                    case "Parent": Navigation.PushAsync(new QuoteDetailPage()); break;
                    case "DHH": Navigation.PushAsync(new DHHDetailPage()); break;
                    case "Resource": Navigation.PushAsync(new ResourceDetailPage()); break;
                }
            }
        }

        void ChangeTheme(string _value, ResourceDictionary _theme)
        {
            Preferences.Set("o_key", _value);
            Application.Current.Resources.MergedDictionaries.Add(_theme);
            UpdateSkiaColor?.Invoke();
        }
        #endregion
    }
}
