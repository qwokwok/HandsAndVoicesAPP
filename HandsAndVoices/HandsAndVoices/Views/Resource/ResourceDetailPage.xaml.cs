using HandsAndVoices.Util;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Resource
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourceDetailPage : ContentPage
    {
        public ResourceDetailPage()
        {
            InitializeComponent();
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        protected override bool OnBackButtonPressed() => false;
    }
}