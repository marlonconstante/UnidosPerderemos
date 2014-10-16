using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RadialProgress;
using System.Drawing;
using UnidosPerderemos.Core.Controls;

[assembly: ExportRenderer(typeof(RadialProgressBar), typeof(UnidosPerderemos.iOS.Renderers.Controls.RadialProgressBarRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class RadialProgressBarRenderer : ViewRenderer<RadialProgressBar, RadialProgressView>
	{
		public RadialProgressBarRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressBar> e)
		{
			base.OnElementChanged(e);

			var radialProgress = new RadialProgressView(RadialProgressViewStyle.Small)
			{
				MinValue = 0,
				MaxValue = 100,
				Center = new PointF(NativeView.Center.X, NativeView.Center.Y - 100),
				Value = Element.Progress,
				ProgressColor = Element.ProgressColor.ToUIColor()
			};

			SetNativeControl(radialProgress);
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (Control == null || Element == null)
				return;

			if (e.PropertyName == RadialProgressBar.ProgressProperty.PropertyName)
			{
				Control.Value = Element.Progress;
			}
			else if (e.PropertyName == RadialProgressBar.ProgressColorProperty.PropertyName)
			{
				Control.ProgressColor = Element.ProgressColor.ToUIColor();
			}
		}


	}
}

