using System;

using Xamarin.Forms;



namespace Ritmodelanoche

{

	public class AbsoluteLayoutDeviceUnits : ContentPage

	{



		int tapCount;

		Label topLeftText, middleText;



		public AbsoluteLayoutDeviceUnits ()

		{

			RelativeLayout simpleLayout = new RelativeLayout {
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var tapGestureRecognizer = 

				new TapGestureRecognizer();

			//tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap

			tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;

			simpleLayout.GestureRecognizers.Add(tapGestureRecognizer);

			topLeftText = new Label {

				Text = "Left",

				TextColor = Color.Black

			};


			simpleLayout.Children.Add (
				topLeftText,
				Constraint.RelativeToParent ((parent) =>{
					return	(parent.Width - topLeftText.Width ) / 2;
				}),
				Constraint.RelativeToParent((parent) => {
					return	(parent.Height - topLeftText.Height ) / 2;
				})
			);

			/*
			simpleLayout.Children.Add (topLeftText);

			simpleLayout.Children.Add (middleText);
			*/


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

			topLeftText.Text = String.Format("{0} tap{1} so far!",

				tapCount,

				tapCount == 1 ? "" : "s");

		}



	}

}

