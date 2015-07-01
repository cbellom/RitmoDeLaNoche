using System;

using Xamarin.Forms;

namespace Ritmodelanoche
{
	public class App : Application
	{


		public App ()
		{
			var main = new RitmoDeLaNocheMainPage ();
			MainPage = main;
		}

		protected override void OnStart ()
		{

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



