using System;

using Xamarin.Forms;



namespace Ritmodelanoche
{
	public class AbsoluteLayoutDeviceUnits : ContentPage
	{
		int tapCount;

		ScoreLabel topLeftText;
		Image CounterFrame;
		Image CounterBar;
		Image TapSuccess;

		public AbsoluteLayoutDeviceUnits ()
		{
			RelativeLayout simpleLayout = new RelativeLayout {
				BackgroundColor = Color.FromHex("#27AAE1"),
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

			// Accomodate iPhone status bar.

			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			this.Content = new StackLayout {
				Children = {
					simpleLayout
				}
			};
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

