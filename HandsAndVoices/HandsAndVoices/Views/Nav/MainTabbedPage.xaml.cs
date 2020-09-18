using System;
using System.Collections.Generic;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Resource;
using HandsAndVoices.Views.Tab;
using Xamarin.Forms;

namespace HandsAndVoices.Views.Nav
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            this.Children.Add(new HomePage());

            this.Children.Add(new ArticleListPage());

            this.Children.Add(new TabPage());

            this.Children.Add(new ResourceListPage());

            this.Children.Add(new AboutPage());

            CurrentPageChanged += CurrentPageHasChanged;
        }

        private void CurrentPageHasChanged(object sender, EventArgs e)
        {
            var index = this.Children.IndexOf(this.CurrentPage);

            switch (index)
            {
                case 1: App.Section = "Article"; break;
                case 2: App.Section = "Quote"; break;
                case 3: App.Section = "Resource"; break;
            }
        }
    }
}
