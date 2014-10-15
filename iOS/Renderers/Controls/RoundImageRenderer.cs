using System;
using Xamarin.Forms.Platform.iOS;
using UnidosPerderemos.Core.Controls;
using Xamarin.Forms;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using System.Drawing;

[assembly: ExportRenderer(typeof(RoundImage), typeof(UnidosPerderemos.iOS.Renderers.Controls.RoundImageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class RoundImageRenderer : ImageRenderer
	{
		public RoundImageRenderer()
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
				Target.Layer.CornerRadius = CornerRadius;
				ShadowLayer.AddSublayer(Target.Layer);

				SetNativeControl(BuildImageView());

				Initialized = true;
			}
		}

		/// <summary>
		/// Builds the image view.
		/// </summary>
		/// <returns>The image view.</returns>
		UIImageView BuildImageView() {
			var imageView = new UIImageView {
				Frame = Target.Frame
			};

			imageView.Layer.CornerRadius = CornerRadius;
			imageView.Layer.BorderWidth = 3.5f;
			imageView.Layer.BorderColor = UIColor.White.CGColor;
			imageView.Layer.AddSublayer(ShadowLayer);

			return imageView;
		}

		/// <summary>
		/// Gets the corner radius.
		/// </summary>
		/// <value>The corner radius.</value>
		float CornerRadius {
			get {

				return Math.Min(Size.Width, Size.Height) / 2f;
			}
		}

		/// <summary>
		/// Gets the shadow layer.
		/// </summary>
		/// <value>The shadow layer.</value>
		CALayer ShadowLayer {
			get;
		} = new CALayer {
			ShadowColor = UIColor.Black.CGColor,
			ShadowOffset = new SizeF(0f, 2.5f),
			ShadowOpacity = 0.4f,
			ShadowRadius = 1f
		};

		/// <summary>
		/// Gets the size.
		/// </summary>
		/// <value>The size.</value>
		SizeF Size {
			get {
				return Target.Frame.Size;
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		RoundImage Source {
			get {
				return Element as RoundImage;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UIImageView Target {
			get {
				return Control;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="UnidosPerderemos.iOS.Renderers.Controls.RoundImageRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		} = false;
	}
}