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
using Android.Graphics;

[assembly: ExportRenderer (typeof (ScoreLabel), typeof (ScoreLabelRenderer))]
namespace Ritmodelanoche.Droid
{
	public class ScoreLabelRenderer : LabelRenderer
	{
		public ScoreLabelRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Label> e) {
			base.OnElementChanged (e);
			var label = (TextView) Control; // for example
			Typeface font = Typeface.CreateFromAsset (Forms.Context.Assets, "cs_regular.ttf");
			label.Typeface = font;
		}

	}
}