using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkiaSharpControl
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // we get the current surface from the event args
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.White);
            var circleFill = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Blue
            };

            // draw the circle fill
            canvas.DrawCircle(100, 100, 40, circleFill);

            // create the paint for the circle border
            var circleBorder = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 5
            };

            // draw the circle border
            canvas.DrawCircle(100, 100, 40, circleBorder);
        }
    }
}
