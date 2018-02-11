using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkiaSharpControl.Extension
{
    public static class SkiaExtensions
    {
        public static Xamarin.Forms.Point GetCanvasCenter(this SKImageInfo info)
        {
            var result = new Xamarin.Forms.Point()
            {
                X = info.Width / 2,
                Y = info.Height / 2
            }; 
            return result;
        }
        public static Xamarin.Forms.Point GetCanvasSize(this SKImageInfo info)
        {
            var result = new Xamarin.Forms.Point()
            {
                X = info.Width,
                Y = info.Height
            };
            return result;
        }
    }
}
