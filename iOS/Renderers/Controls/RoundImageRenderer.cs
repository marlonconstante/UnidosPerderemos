using System;
using Xamarin.Forms.Platform.iOS;
using UnidosPerderemos.Core.Controls;
using Xamarin.Forms;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using System.Drawing;
using System.ComponentModel;

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
				Target.Layer.BorderWidth = 3.5f;
				Target.Layer.BorderColor = UIColor.White.CGColor;

				ActivityIndicatorView.Frame = new RectangleF(0f, 0f, Size.Width, Size.Height);
				Target.Add(ActivityIndicatorView);

				Initialized = true;
			}
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(sender, args);

			if (RoundImage.LoadingSourceProperty.PropertyName == args.PropertyName)
			{
				if (Source.LoadingSource)
				{
					ActivityIndicatorView.StartAnimating();
				}
				else
				{
					ActivityIndicatorView.StopAnimating();
				}
			}
			else if (RoundImage.SourceProperty.PropertyName == args.PropertyName)
			{
				Source.LoadingSource = Source.Source == null;
			}
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
		/// Gets the size.
		/// </summary>
		/// <value>The size.</value>
		SizeF Size {
			get {
				return Target.Frame.Size;
			}
		}

		/// <summary>
		/// Gets the activity indicator view.
		/// </summary>
		/// <value>The activity indicator view.</value>
		UIActivityIndicatorView ActivityIndicatorView {
			get;
		} = new UIActivityIndicatorView {
			ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.White
		};

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