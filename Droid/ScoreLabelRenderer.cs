using System;

using Xamarin.Forms;
using Ritmodelanoche;
using Ritmodelanoche.Droid;
using Xamarin.Forms.Platform.Android;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

[assembly: ExportRenderer (typeof (ScoreLabel), typeof (ScoreLabelRenderer))]
namespace Ritmodelanoche.Droid
{
	public class ScoreLabelRenderer : LabelRenderer
	{
		public ScoreLabelRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Label> e) {
		}

	}
}