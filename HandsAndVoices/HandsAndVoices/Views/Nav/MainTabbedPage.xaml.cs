using System;
using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Resource;
using HandsAndVoices.Views.Tab;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace HandsAndVoices.Views.Nav
{
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
                .DisableSwipePaging()
                .SetElevation(1f);

            this.Children.Add(new HomePage());

            this.Children.Add(new ArticleListPage());

            this.Children.Add(new SegmentPage());

            this.Children.Add(new ResourceListPage());

            this.Children.Add(new AboutPage());

            Title = "Categories";
            
            CurrentPageChanged += CurrentPageHasChanged;
        }

        private void CurrentPageHasChanged(object sender, EventArgs e)
        {
            var index = this.Children.IndexOf(this.CurrentPage);

            switch (index)
            {
                case 0: Title = "Categories"; break;
                case 1: App.Section = "Article"; Title = "Articles"; break;
                case 2: App.Section = "Parent"; Title = "Quotes"; break;
                case 3: App.Section = "Resource"; Title = "Resources"; break;
                case 4: Title = "About Us"; break;
            }
        }
    }
}
