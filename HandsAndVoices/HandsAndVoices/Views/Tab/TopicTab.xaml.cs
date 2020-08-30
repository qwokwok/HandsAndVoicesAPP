using HandsAndVoices.Views.Article;
using HandsAndVoices.Views.Quote;
using HandsAndVoices.Views.Resource;
using System;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Tab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicTab : Xamarin.Forms.TabbedPage
    {
        public TopicTab()
        {
            Title = App.Selected.DayString;
            App.Section = "Article";
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
                .DisableSwipePaging()
                .SetElevation(1f);

            InitializeComponent();

            this.Children.Add(new ArticleDetailPage() { Title = "Article", IconImageSource = "resourceIcon" });
            this.Children.Add(new QuoteDetailPage() { Title = "Parent", IconImageSource = "parentIcon" });
            this.Children.Add(new DHHDetailPage() { Title = "DHH", IconImageSource = "dhhIcon" });
            this.Children.Add(new ResourceDetailPage() { Title = "Resource", IconImageSource = "adviceIcon" });

            CurrentPageChanged += CurrentPageHasChanged;
        }

        private void CurrentPageHasChanged(object sender, EventArgs e)
        {
            var index = this.Children.IndexOf(this.CurrentPage);

            switch(index)
            {
                case 0: App.Section = "Article"; break;
                case 1: App.Section = "Quote"; break;
                case 2: App.Section = "Quote"; break;
                case 3: App.Section = "Resource"; break;
            }
        }
    }
}