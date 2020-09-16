using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HandsAndVoices.Util
{
    public static class Painter
    {
        public static void PaintGradientBG(SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                // Create linear gradient from top to bottom
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(e.Info.Width / 2, 0),
                                    new SKPoint(e.Info.Width / 2, e.Info.Height),
                                    //new SKColor[] { ((Color)App.Current.Resources[App.ResourceKeys.GRADIENT_BLUE]).ToSKColor(), ((Color)App.Current.Resources[App.ResourceKeys.GRADIENT_ORAN]).ToSKColor() },
                                    new SKColor[] { ((Color)App.Current.Resources["Top"]).ToSKColor(), ((Color)App.Current.Resources["Bottom"]).ToSKColor(), ((Color)App.Current.Resources["Bottom"]).ToSKColor() },
                                    null,
                                    SKShaderTileMode.Repeat);

                // Draw the gradient on the rectangle
                canvas.DrawRect(0, 0, e.Info.Width, e.Info.Height, paint);
            }
        }
    }
}
