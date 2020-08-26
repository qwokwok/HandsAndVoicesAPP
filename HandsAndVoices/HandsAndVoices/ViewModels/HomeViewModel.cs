using HandsAndVoices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HandsAndVoices.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private List<Example> articleList;
        public List<Example> ArticleList
        {
            get => articleList;
            set
            {
                articleList = value;
                NotifyPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            // sample list
            articleList = new List<Example>();
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
            articleList.Add(new Example() { Image = "tree.png", IsNew = true, Topic = "Welcome to the Journey", Url = "https://youtu.be/23sns-_NZYg" });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Pass in a single property to cause a UI update.
        /// </summary>
        protected void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
