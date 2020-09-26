using HandsAndVoices.Util;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Quote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DHHDetailPage : ContentPage
    {
        public DHHDetailPage()
        {
            InitializeComponent();
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);
    }
}