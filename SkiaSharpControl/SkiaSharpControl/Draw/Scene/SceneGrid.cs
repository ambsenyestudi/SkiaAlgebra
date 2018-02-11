using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace SkiaSharpControl.Draw.Scene
{
    public class SceneGrid:BaseShape
    {
        public Point MaxSize { get; protected set; }
        public Point MinSize { get; protected set; }
        public SKPaint XStroke { get; protected set; }
        public SKPaint YStroke { get; protected set; }
        public float UnitSize { get; set; }
        private float defaultStrokeWidth = 5f;
        private float defaultUnitSegementSize = 30f;
        public SceneGrid(Point center, Point maxSize, float unitSize = 1f)
        {
            double min = Math.Min(maxSize.X, maxSize.Y);
            defaultUnitSegementSize = (float)(min / 20);
            XStroke = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = defaultStrokeWidth
            };
            YStroke = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Green,
                StrokeWidth = defaultStrokeWidth
            };
            this.Center = center;
            MaxSize = maxSize;
            UnitSize = unitSize;
        }
        public SceneGrid(Point center, Point maxSize, Point minSize, float unitSize = 1f) :this(center, maxSize, unitSize)
        {
            MinSize = minSize;
        }
        public void Draw(SKCanvas canvas)
        {
            var xPath = new SKPath();
            xPath.MoveTo(0, (int)Center.Y);
            xPath.LineTo((int)MaxSize.X, (int)Center.Y);
            canvas.DrawPath(xPath, XStroke);
            var yPath = new SKPath();
            yPath.MoveTo((int)Center.X, 0);
            yPath.LineTo((int)Center.X, (int)(Center.Y * 2));
            canvas.DrawPath(yPath, YStroke);
            DrawUnitSegements(canvas);
        }
        public void DrawUnitSegements(SKCanvas canvas)
        {
            double xSize = Math.Min((MaxSize.X - MinSize.X), (MaxSize.Y - MinSize.Y));
            xSize /= 2;
            double segWidth = (xSize / UnitSize) - defaultStrokeWidth;
            int totalaSegments = (int)(xSize / segWidth);
            for (int i = 0; i < totalaSegments; i++)
            {
                float currSeg = (float)(segWidth * (i + 1));
                var leftPath = new SKPath();
                leftPath.MoveTo((int)(Center.X - currSeg), (int)(Center.Y - defaultUnitSegementSize));
                leftPath.LineTo((int)(Center.X - currSeg), (int)(Center.Y + defaultUnitSegementSize));
                canvas.DrawPath(leftPath, XStroke);
                var rightPath = new SKPath();
                rightPath.MoveTo((int)(Center.X + currSeg), (int)(Center.Y - defaultUnitSegementSize));
                rightPath.LineTo((int)(Center.X + currSeg), (int)(Center.Y + defaultUnitSegementSize));
                canvas.DrawPath(rightPath, XStroke);
                var topPath = new SKPath();
                topPath.MoveTo((int)(Center.X - defaultUnitSegementSize), (int)(Center.Y - currSeg));
                topPath.LineTo((int)(Center.X + defaultUnitSegementSize), (int)(Center.Y - currSeg));
                canvas.DrawPath(topPath, YStroke);
                var bottomPath = new SKPath();
                bottomPath.MoveTo((int)(Center.X - defaultUnitSegementSize), (int)(Center.Y + currSeg));
                bottomPath.LineTo((int)(Center.X + defaultUnitSegementSize), (int)(Center.Y + currSeg));
                canvas.DrawPath(bottomPath, YStroke);
            }
        }
    }
}
