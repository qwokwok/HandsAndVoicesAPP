using HandsAndVoices.Models;
using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Article
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleDetailPage : ContentPage
    {
        public DetailViewModel VM => (DetailViewModel)BindingContext;
        public ArticleDetailPage()
        {
            InitializeComponent();
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        protected override bool OnBackButtonPressed() => false;
    }
}