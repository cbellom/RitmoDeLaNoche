using System;
using System.Diagnostics;
using Xamarin.Forms;



namespace Ritmodelanoche
{
	public class RitmoDeLaNocheMainPage : ContentPage
	{
		int tapCount;

		ScoreLabel topLeftText;
		Image CounterFrame;
		Image CounterBar;
		Image TapSuccess;
		private BoxView box;
		private double duration = 2000;
		private double elapsedTime = 0;

		AbsoluteLayout absoluteLayout;


		public RitmoDeLaNocheMainPage ()
		{
			absoluteLayout = new AbsoluteLayout();
			box = new BoxView { Color = Color.Accent };

			absoluteLayout.Children.Add (box);

			SizeChanged += HandlePageSizeChanged;
			Device.StartTimer(TimeSpan.FromMilliseconds(16), HandleTimerTick);



			RelativeLayout simpleLayout = new RelativeLayout {
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var tapGestureRecognizer = new TapGestureRecognizer();

			tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
			simpleLayout.GestureRecognizers.Add(tapGestureRecognizer);

			topLeftText = new ScoreLabel {
				Text = "0",
				TextColor = Color.White,
				FontSize = 36
			};

			CounterBar = new Image {
				Source="barra_contador"
			};

			CounterFrame = new Image {
				Source="marco_contador"
			};

			TapSuccess = new Image {
				Source = "tap_exito"
			};

			simpleLayout.Children.Add (
				absoluteLayout ,
				Constraint.RelativeToParent ((parent) =>{
					return 0;
				}),
				Constraint.RelativeToParent((parent) => {
					return	0;
				})
			);

			simpleLayout.Children.Add (
				CounterBar,
				Constraint.RelativeToParent ((parent) =>{
					return 0;
				}),
				Constraint.RelativeToParent((parent) => {
					return	(parent.Height - CounterBar.Height ) / 2;
				})
			);


			simpleLayout.Children.Add (
				CounterFrame,
				Constraint.RelativeToParent ((parent) =>{
					return (parent.Width - CounterFrame.Width ) / 2;
				}),
				Constraint.RelativeToParent((parent) => {
					return	(parent.Height - CounterFrame.Height ) / 2;
				})
			);

			simpleLayout.Children.Add (
				topLeftText,
				Constraint.RelativeToParent ((parent) =>{
					return	(parent.Width - topLeftText.Width ) / 2;
				}),
				Constraint.RelativeToParent((parent) => {
					return	(parent.Height - topLeftText.Height ) / 2;
				})
			);

			simpleLayout.Children.Add (
				TapSuccess,
				Constraint.RelativeToParent ((parent) =>{
					return	(parent.Width - TapSuccess.Width ) / 2;
				}),
				Constraint.RelativeToParent((parent) => {
					return	(parent.Height - TapSuccess.Height ) / 2;
				})
			);

			this.Content = new StackLayout {
				Children = {
					simpleLayout
				}
			};
		}

		void HandlePageSizeChanged(object sender, EventArgs args)
		{
			drawBox (this.Height);
		}

		bool HandleTimerTick()
		{
			if (elapsedTime + 16 > duration)
				elapsedTime = 0;
			elapsedTime += 16;
			double cutoff = (this.Height * elapsedTime) / duration;
			if (this.Height - cutoff <= 0)
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

			
		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
			tapCount++;
			topLeftText.Text = String.Format(
				"{0}",
				tapCount);
		}
	}
}

