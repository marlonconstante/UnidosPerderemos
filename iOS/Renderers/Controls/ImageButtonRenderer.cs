using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using MonoTouch.UIKit;

[assembly: ExportRenderer(typeof(ImageButton), typeof(UnidosPerderemos.iOS.Renderers.Controls.ImageButtonRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class ImageButtonRenderer : ButtonRenderer
	{
		public ImageButtonRenderer()
		{
		}

		/// <Docs>Lays out subviews.</Docs>
		/// <summary>
		/// Layouts the subviews.
		/// </summary>
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			if (!Initialized)
			{
				Target.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
				Target.SetImage(OriginalImage, UIControlState.Normal);

				Initialized = true;
			}
		}

		/// <summary>
		/// Gets the original image.
		/// </summary>
		/// <value>The original image.</value>
		UIImage OriginalImage {
			get {
				return Target.CurrentImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
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

		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="UnidosPerderemos.iOS.Renderers.Controls.ImageButtonRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		} = false;
	}
}