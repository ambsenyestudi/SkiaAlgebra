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
	public partial class PresentedView : ContentView
	{
		public PresentedView ()
		{
			InitializeComponent ();
            BindingContext = this;
		}


        public string Hello
        {
            get { return (string)GetValue(HelloProperty); }
            set { SetValue(HelloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hello.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty HelloProperty =
            BindableProperty.Create("Hello", typeof(string), typeof(PresentedView), "Default greeting");


    }
}