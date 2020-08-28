using HandsAndVoices.Models;
using HandsAndVoices.Util;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Quote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage(Advice _advice)
        {
            InitializeComponent();
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);
    }
}