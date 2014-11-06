﻿using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UnidosPerderemos.Core.Controls;
using MonoTouch.UIKit;
using System;

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

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			if (Source.Progress > 0)
				LoadImageView(Math.Ceiling(Source.Progress / 10f) * 10);
			else
				LoadImageView(0);
		}

		/// <summary>
		/// Loads the image view.
		/// </summary>
		/// <param name="progress">Progress.</param>
		void LoadImageView(double progress)
		{
			if (progress > 0)
				SetNativeControl(new UIImageView(new UIImage(string.Concat(Source.ProgressType, progress, ".png"))));
		}
	}
}

