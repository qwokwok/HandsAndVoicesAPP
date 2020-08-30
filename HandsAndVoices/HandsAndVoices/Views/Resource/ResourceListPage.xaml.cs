using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Resource
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourceListPage : ContentPage
    {
        public SectionViewModel VM => (SectionViewModel)BindingContext;
        public ResourceListPage()
        {
            InitializeComponent();

            VM.Navigation = Navigation;
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        protected override bool OnBackButtonPressed() => true;
    }
}