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

			AbsoluteLayout simpleLayout = new AbsoluteLayout {



				BackgroundColor = Color.Blue.WithLuminosity (0.9),

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



			AbsoluteLayout.SetLayoutFlags (topLeftText,

				AbsoluteLayoutFlags.None);



			AbsoluteLayout.SetLayoutBounds (topLeftText,

				new Rectangle (0f, 0f,  100f, 50f));



			middleText = new Label {

				Text = "Device-dependent location",

				TextColor = Color.Black

			};



			AbsoluteLayout.SetLayoutFlags (middleText,

				AbsoluteLayoutFlags.None);



			AbsoluteLayout.SetLayoutBounds (middleText,

				new Rectangle (100f, 200f, 200f, 50f));



			simpleLayout.Children.Add (topLeftText);

			simpleLayout.Children.Add (middleText);



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

