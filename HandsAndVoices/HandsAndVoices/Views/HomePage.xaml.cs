using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
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

            VM.UpdateSkiaColor += delegate { SKCanvas.InvalidateSurface(); };
        }
        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        protected override bool OnBackButtonPressed() => true;
    }
}