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
using Android.Util;

[assembly: ExportRenderer (typeof (Label), typeof (ScoreLabelRenderer))]
namespace Ritmodelanoche.Droid
{
	public class ScoreLabelRenderer : LabelRenderer
	{
		private const string Tag = "ScoreLabelRenderer";
		
		public ScoreLabelRenderer ()
		{
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "Fonts/cs_regular.ttf" );

			var label = Control as TextView;
			
			if (label != null)
				label.Typeface = typeface;		
		}
	}
}