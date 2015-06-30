using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Ritmodelanoche
{
	public class TimedBoxPage : ContentPage
	{
		private BoxView box;
		private double duration = 2000;
		private double elapsedTime = 0;
		private Stopwatch stopWatch = new Stopwatch();

		public TimedBoxPage ()
		{
			AbsoluteLayout absoluteLayout = new AbsoluteLayout();

			box = new BoxView { Color = Color.Accent };

			absoluteLayout.Children.Add (box);

			SizeChanged += HandlePageSizeChanged;

			Device.StartTimer(TimeSpan.FromMilliseconds(16), HandleTimerTick);

			Content = absoluteLayout;
		}

		void HandlePageSizeChanged(object sender, EventArgs args)
		{
			drawBox (this.Height);
		}

		bool HandleTimerTick()
		{
			elapsedTime += 16;
			double cutoff = (this.Height * elapsedTime) / duration;
			if (box.Height - cutoff <= 0)
				drawBox(this.Height);
			else
				drawBox(this.Height - cutoff);
			return true;
		}

		private void drawBox()
		{
			drawBox(this.Height);
		}

		private void drawBox(double height)
		{
			double y = this.Height - height;
			AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0, y, this.Width, height));
		}
	}
}

