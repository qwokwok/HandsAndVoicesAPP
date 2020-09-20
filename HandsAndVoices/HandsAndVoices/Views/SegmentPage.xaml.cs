﻿using HandsAndVoices.Util;
using HandsAndVoices.ViewModels;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentPage : ContentPage
    {
        public SegmentViewModel VM => (SegmentViewModel)BindingContext;
        public SegmentPage()
        {
            InitializeComponent();

            VM.Navigation = Navigation;

            App.Section = "Parent";
        }

        private void SKCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e) => Painter.PaintGradientBG(e);

        private void SegmentedControl_OnSegmentSelected(object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e)
        {
            var val = e.NewValue;
            if (val == 0)
            {
                collection1.IsVisible = true;
                collection2.IsVisible = false;
                App.Section = "Parent";
            }

            else
            {
                collection1.IsVisible = false;
                collection2.IsVisible = true;
                App.Section = "DHH";
            }
        }
    }
}