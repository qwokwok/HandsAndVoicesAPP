using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using HandsAndVoices.Views.Nav;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomeViewModel VM => (HomeViewModel)BindingContext;
        public HomePage()
        {
            InitializeComponent();

            VM.Navigation = Navigation;

            var day = (int)App.ReseveredAdvices[0].Day;

            if (day > Preferences.Get("day_key", 1))
            {
                Preferences.Set("article_key", false);
                Preferences.Set("parent_key", false);
                Preferences.Set("dhh_key", false);
                Preferences.Set("resource_key", false);
                Preferences.Set("day_key", day);
            }

            if (!Preferences.Get("article_key", false)
                || !Preferences.Get("parent_key", false)
                || !Preferences.Get("dhh_key", false)
                || !Preferences.Get("resource_key", false))
                Navigation.PushModalAsync(new TransparentNavigationPage(new ExplorePage()) { BarTextColor = Color.White });

            VM.UpdateSkiaColor += delegate { SKCanvas.InvalidateSurface(); };
        }
        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        protected override bool OnBackButtonPressed() => true;
    }
}