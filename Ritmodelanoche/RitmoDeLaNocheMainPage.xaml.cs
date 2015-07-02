using System;
using System.Collections.Generic;

using Xamarin.Forms;



namespace Ritmodelanoche
{
	public partial class RitmoDeLaNocheMainPage : ContentPage
	{
		private const double ValidTapMinimumBoxFill = 0.4;
		private const double ValidTapMaximumBoxFill = 0.6;

		int tapCount;
		bool tapIsValid;
		bool receivingTaps;

		Label scoreLabel;
		private BoxView box;
		private double duration = 2000;
		private double elapsedTime = 0;

		AbsoluteLayout drawablesWrapper;
		AbsoluteLayout boxWrapper;

		Image tapSuccessIndicatorImage;

		public RitmoDeLaNocheMainPage ()
		{
			InitializeComponent ();

			tapIsValid = false;

			drawablesWrapper = this.FindByName<AbsoluteLayout>("drawables_wrapper");
			box = new BoxView{Color = Color.Accent};
			scoreLabel = this.FindByName<Label> ("score_label");
			boxWrapper = this.FindByName<AbsoluteLayout> ("timed_box_wrapper");

			boxWrapper.Children.Add (box);

			SizeChanged += HandlePageSizeChanged;
			Device.StartTimer(TimeSpan.FromMilliseconds(16), HandleTimerTick);

			var tapGestureRecognizer = new TapGestureRecognizer();

			tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
			drawablesWrapper.GestureRecognizers.Add(tapGestureRecognizer);

			tapSuccessIndicatorImage = this.FindByName<Image>("tap_success_indicator");
			tapSuccessIndicatorImage.IsVisible = false;
		}

		void HandlePageSizeChanged(object sender, EventArgs args)
		{
			drawBox (this.Height);
		}

		bool HandleTimerTick()
		{
			if (elapsedTime + 16 > duration) {
				elapsedTime = 0;
				resetTapSuccessIndicator ();
			}
			elapsedTime += 16;
			double cutoff = (this.Height * elapsedTime) / duration;
			if (this.Height - cutoff <= 0)
				drawBox(this.Height);
			else
				drawBox(this.Height - cutoff);

			setTapValidity(this.Height, cutoff);

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

			
		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
			if (receivingTaps) {
				if (tapIsValid) {
					tapCount++;
					scoreLabel.Text = String.Format(
						"{0}",
						tapCount);
				}

				receivingTaps = false;

				drawTapSuccessIndicator ();
			}
		}

		void drawTapSuccessIndicator(){
			if (tapIsValid) {
				tapSuccessIndicatorImage.Source = "tap_exito.png";
			} else {
				tapSuccessIndicatorImage.Source = "tap_error.png";
			}

			tapSuccessIndicatorImage.IsVisible = true;
		}

		void setTapValidity(double height, double cutoff){
			double percentage = cutoff/height;

			if (percentage >= ValidTapMinimumBoxFill && percentage <= ValidTapMaximumBoxFill) {
				tapIsValid = true;
			} else {
				tapIsValid = false;
			}
		}

		void resetTapSuccessIndicator(){
			tapSuccessIndicatorImage.IsVisible = false;
			receivingTaps = true;
		}

	}
}

