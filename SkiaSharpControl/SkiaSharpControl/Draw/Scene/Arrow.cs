using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkiaSharpControl.Draw.Scene
{
    public class Arrow:BaseShape
    {
        public SKColor Color { get; protected set; }
        public Arrow(Point direction, SKColor color)
        {
            Color = Color;
            //Todo paint and make a stroke base shape that has default width
        }
    }
}
