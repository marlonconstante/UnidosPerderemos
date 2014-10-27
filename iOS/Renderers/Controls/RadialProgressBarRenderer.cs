using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RadialProgress;
using System.Drawing;
using UnidosPerderemos.Core.Controls;
using System.ComponentModel;
using MonoTouch.UIKit;

[assembly: ExportRenderer(typeof(RadialProgressBar), typeof(UnidosPerderemos.iOS.Renderers.Controls.RadialProgressBarRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class RadialProgressBarRenderer : ImageRenderer
	{
		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		RadialProgressBar Source
		{
			get
			{
				return Element as RadialProgressBar;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UIImageView Target
		{
			get
			{
				return Control;
			}
		}


		public RadialProgressBarRenderer()
		{
		}



		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			if (Source.Progress == 70)
				SetNativeControl(new UIImageView(new UIImage("70percent.png")));
			else
				SetNativeControl(new UIImageView(new UIImage("100percent.png")));
		}

//		protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressBar> e)
//		{
//			base.OnElementChanged(e);
//
//			var radialProgress = new RadialProgressView(RadialProgressViewStyle.Big)
//			{
//				MinValue = 0,
//				MaxValue = 100,
////				Center = new PointF(NativeView.Center.X, NativeView.Center.Y - 100),
//				Value = Source.Progress,
//				ProgressColor = Element.ProgressColor.ToUIColor(),
//				BackgroundColor = Color.Blue.ToUIColor(),
////				AutoresizingMask = MonoTouch.UIKit.UIViewAutoresizing.All,
//				AutosizesSubviews = true,
//				ClipsToBounds = true,
//				ContentMode = MonoTouch.UIKit.UIViewContentMode.ScaleAspectFit
//			};
//
//
//			SetNativeControl(radialProgress);
//		}

//		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//		{
//			if (Control == null || Element == null)
//				return;
//
//			if (e.PropertyName == RadialProgressBar.ProgressProperty.PropertyName)
//			{
//				Control.Value = Element.Progress;
//			}
//			else if (e.PropertyName == RadialProgressBar.ProgressColorProperty.PropertyName)
//			{
//				Control.ProgressColor = Element.ProgressColor.ToUIColor();
//			}
//		}
//

	}
}

