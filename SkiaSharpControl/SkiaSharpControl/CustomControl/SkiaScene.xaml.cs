using SkiaSharp;
using SkiaSharp.Views.Forms;
using SkiaSharpControl.Draw.Scene;
using SkiaSharpControl.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkiaSharpControl.CustomControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SkiaScene : ContentView
	{
		public SkiaScene ()
		{
			InitializeComponent ();
		}
        public SceneGrid grid { get; set; }
        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            SKImageInfo info = e.Info;
            // we get the current surface from the event args
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.White);
            if(grid==null)
            {
                grid = new SceneGrid(info.GetCanvasCenter(), info.GetCanvasSize(), 3f);
            }
            grid.Draw(canvas);
        }

        private static void drawCross(SKImageInfo info, SKCanvas canvas)
        {
            Point center = info.GetCanvasCenter();

            var pathStroke = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Green,
                StrokeWidth = 5
            };

            // create a path
            var path = new SKPath();
            path.MoveTo(0, (int)center.Y);
            path.LineTo((int)(center.X * 2), (int)center.Y);
            path.MoveTo((int)center.X, 0);
            path.LineTo((int)center.X, (int)(center.Y * 2));

            // draw the path
            canvas.DrawPath(path, pathStroke);
        }

        private void DrawCircle(SKCanvas canvas)
        {
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