using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicPage : ContentPage
    {
        public TopicViewModel VM => (TopicViewModel)BindingContext;
        public TopicPage()
        {
            InitializeComponent();

            VM.Navigation = Navigation;
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        protected override bool OnBackButtonPressed() => false;
    }
}