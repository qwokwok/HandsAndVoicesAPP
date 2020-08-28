using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}