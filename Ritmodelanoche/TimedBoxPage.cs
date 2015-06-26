using System;
using Xamarin.Forms;

namespace Ritmodelanoche
{
	public class TimedBoxPage : ContentPage
	{
		public TimedBoxPage ()
		{
			AbsoluteLayout absoluteLayout = new AbsoluteLayout();

			BoxView box = new BoxView { Color = Color.Accent };

			AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0, 0, this.Width, this.Height));

			absoluteLayout.Children.Add (box);
			Content = absoluteLayout;
		}
	}
}

