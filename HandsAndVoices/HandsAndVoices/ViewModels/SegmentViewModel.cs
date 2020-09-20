using HandsAndVoices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class SegmentViewModel : BasicViewModel
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
    }
}
