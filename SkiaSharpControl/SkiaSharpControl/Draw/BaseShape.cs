using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkiaSharpControl.Draw
{
    public abstract class BaseShape
    {
        public Point Center { get; protected set; }
        public float Radius { get { return GetRadius(); } }

        public virtual float GetRadius()
        {
            return 0f;
        }
    }
}
