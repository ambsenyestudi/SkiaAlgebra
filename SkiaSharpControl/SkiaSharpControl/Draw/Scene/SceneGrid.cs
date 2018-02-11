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
            double xminSize = Math.Min((MaxSize.X - MinSize.X), (MaxSize.Y - MinSize.Y))/2;
            xminSize -= defaultStrokeWidth / 2;
            double segWidth = (xminSize / UnitSize);
            double xmaxSize = Math.Max((MaxSize.X - MinSize.X), (MaxSize.Y - MinSize.Y))/2;
            int totalaSegments = (int)(xmaxSize / segWidth);
            for (int i = 0; i < totalaSegments; i++)
            {
                float currSeg = (float)(segWidth * (i + 1));

                int leftOrg = (int)(Center.X - currSeg);
                if (leftOrg > MinSize.X)
                {
                    var leftPath = new SKPath();
                    leftPath.MoveTo(leftOrg, (int)(Center.Y - defaultUnitSegementSize));
                    leftPath.LineTo(leftOrg, (int)(Center.Y + defaultUnitSegementSize));
                    canvas.DrawPath(leftPath, XStroke);
                }
                int rightOrg = (int)(Center.X + currSeg);
                if(rightOrg < MaxSize.X)
                {
                    var rightPath = new SKPath();
                    rightPath.MoveTo(rightOrg, (int)(Center.Y - defaultUnitSegementSize));
                    rightPath.LineTo(rightOrg, (int)(Center.Y + defaultUnitSegementSize));
                    canvas.DrawPath(rightPath, XStroke);
                }
                int topOrg = (int)(Center.Y - currSeg);
                if (topOrg > MinSize.Y)
                {
                    var topPath = new SKPath();
                    topPath.MoveTo((int)(Center.X - defaultUnitSegementSize), topOrg);
                    topPath.LineTo((int)(Center.X + defaultUnitSegementSize), topOrg);
                    canvas.DrawPath(topPath, YStroke);
                }
                int bottomOrg = (int)(Center.Y + currSeg);
                if (bottomOrg < MaxSize.Y) {
                    var bottomPath = new SKPath();
                    bottomPath.MoveTo((int)(Center.X - defaultUnitSegementSize), bottomOrg);
                    bottomPath.LineTo((int)(Center.X + defaultUnitSegementSize), bottomOrg);
                    canvas.DrawPath(bottomPath, YStroke);
                }
            }
        }
    }
}
