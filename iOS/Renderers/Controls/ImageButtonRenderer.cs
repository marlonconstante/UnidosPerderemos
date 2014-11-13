using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using MonoTouch.UIKit;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ImageButton), typeof(UnidosPerderemos.iOS.Renderers.Controls.ImageButtonRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class ImageButtonRenderer : ButtonRenderer
	{
		public ImageButtonRenderer()
		{
		}

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Button> args)
		{
			base.OnElementChanged(args);

			UpdateImage();
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(sender, args);

			if (ImageButton.ImageProperty.PropertyName == args.PropertyName)
			{
				UpdateImage();
			}
		}

		/// <summary>
		/// Updates the image.
		/// </summary>
		void UpdateImage()
		{
			Target.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			Target.SetImage(OriginalImage, UIControlState.Normal);
		}

		/// <summary>
		/// Gets the original image.
		/// </summary>
		/// <value>The original image.</value>
		UIImage OriginalImage {
			get {
				if (Target.CurrentImage != null)
				{
					return Target.CurrentImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		ImageButton Source {
			get {
				return Element as ImageButton;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UIButton Target {
			get {
				return Control;
			}
		}
	}
}