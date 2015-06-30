using System;

using Xamarin.Forms;
using Ritmodelanoche;
using Ritmodelanoche.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (ScoreLabel), typeof (ScoreLabelRenderer))]
namespace Ritmodelanoche.Droid
{
	public class ScoreLabelRenderer : LabelRenderer
	{
		public ScoreLabelRenderer ()
		{
		}

	}
}