using HandsAndVoices.Models;
using HandsAndVoices.Views.Tab;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class TopicViewModel : BasicViewModel
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
        public Command ReviewCommand { get; set; }
        #endregion

        public TopicViewModel()
        {
            ReviewCommand = new Command<Advice>(PushReview);
        }

        void PushReview(Advice advice)
        {
            App.Selected = advice;

            if(advice.Day != 0)
                Navigation.PushAsync(new TopicTab());
        }
    }
}
