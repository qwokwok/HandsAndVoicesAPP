using HandsAndVoices.Views.Quote;
using System;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Tab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : Xamarin.Forms.TabbedPage
    {
        public static int Index { get; set; }
        public TabPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
                .DisableSwipePaging()
                .SetElevation(1f);

            InitializeComponent();

            Title = "Parent Quotes";

            this.Children.Add(new ParentListPage() { Title = "Parent Quotes", IconImageSource="parentIcon" });
            this.Children.Add(new DHHListPage() { Title = "DHH quotes", IconImageSource = "dhhIcon" });

            CurrentPageChanged += CurrentPageHasChanged;
        }

        private void CurrentPageHasChanged(object sender, EventArgs e)
        {
            var index = this.Children.IndexOf(this.CurrentPage);
            Title = index == 0 ? "Parent Quotes" : "Deaf and Hard of Hearing Quotes";
            switch(index)
            {
                case 0: App.Section = "Parent"; break;
                case 1: App.Section = "Parent"; break;
            }
        }
    }
}