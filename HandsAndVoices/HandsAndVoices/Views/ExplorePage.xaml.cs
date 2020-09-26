using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExplorePage : ContentPage
    {
        public ExploreViewModel VM => (ExploreViewModel)BindingContext;
        public ExplorePage()
        {
            InitializeComponent();

            ScaleDown(articleCheck, "article_key");
            ScaleDown(parentCheck, "parent_key");
            ScaleDown(dhhCheck, "dhh_key");
            ScaleDown(resourceCheck, "resource_key");

            bottomBar.TranslationY = 100;

            VM.Navigation = Navigation;
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        private void ScaleDown(Image image, string key)
        {
            if (!Preferences.Get(key, false))
                image.Scale = 0;
        }

        private void ScaleUp(Image image, string key)
        {
            if (Preferences.Get(key, false))
                image.ScaleTo(1, 100, null);
        }

        protected override void OnAppearing()
        {
            IsEnabled = true;

            ScaleUp(articleCheck, "article_key");
            ScaleUp(parentCheck, "parent_key");
            ScaleUp(dhhCheck, "dhh_key");
            ScaleUp(resourceCheck, "resource_key");

            if (Preferences.Get("article_key", false)
                && Preferences.Get("parent_key", false)
                && Preferences.Get("dhh_key", false)
                && Preferences.Get("resource_key", false))
                bottomBar.TranslateTo(0, 0, 250, null);

                base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            IsEnabled = false;
            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed() => true;
    }    
}