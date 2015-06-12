using System;

using Xamarin.Forms;

namespace Ritmodelanoche
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			/*MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};*/

			var tabs = new TabbedPage ();

			// demonstrates an Image tap (and changing the image)
			//tabs.Children.Add (new TapInsideImage {Title = "Image", Icon = "csharp.png" });

			// demonstrates adding GestureRecognizer to a Frame
			//tabs.Children.Add ( new TapInsideFrame {Title = "Frame", Icon = "csharp.png" });

			// demonstrates adding GestureRecognizer to a Frame
			tabs.Children.Add ( new AbsoluteLayoutDeviceUnits {Title = "Nuevo", Icon = "csharp.png" });

			// demonstrates using Xaml, Command and databinding
			//tabs.Children.Add (new TapInsideFrameXaml {Title = "In Xaml", Icon = "xaml.png" });

			MainPage = tabs;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

