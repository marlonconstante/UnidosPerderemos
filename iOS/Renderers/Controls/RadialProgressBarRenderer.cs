using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RadialProgress;
using System.Drawing;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class RadialProgressBarRenderer : ViewRenderer<RadialProgressBar, RadialProgressBarRenderer>
	{
		public RadialProgressBarRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressBar> e)
		{
			base.OnElementChanged(e);

			var progressView = new RadialProgressView
			{
				Center = new PointF(100, 100)
			};
			NativeView.AddSubview(progressView);
		}
	}
}

