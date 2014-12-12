using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos;
using MonoTouch.UIKit;
using UnidosPerderemos.Core.Controls;
using MonoTouch.CoreAnimation;
using System.Drawing;
using System.ComponentModel;
using MonoTouch.Foundation;
using System.IO;

[assembly: ExportRenderer(typeof(TextArea), typeof(UnidosPerderemos.iOS.Renderers.Controls.TextAreaRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class TextAreaRenderer : EditorRenderer
	{
		public TextAreaRenderer()
		{
		}

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> args)
		{
			base.OnElementChanged(args);

			SetUp();
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(sender, args);

			if (TextArea.BackgroundImageProperty.PropertyName == args.PropertyName)
			{
				var backgroundImage = UIImage.LoadFromData(NSData.FromStream(Source.BackgroundImage ?? Stream.Null));
				BackgroundImageView.Image = backgroundImage;
			}
		}

		/// <Docs>Lays out subviews.</Docs>
		/// <summary>
		/// Layouts the subviews.
		/// </summary>
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			BackgroundImageView.Frame = Target.Frame;
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			if (!Initialized)
			{
				Target.Font = Source.Font.ToUIFont();
				Target.TextColor = Source.TextColor.ToUIColor();
				Target.TextContainerInset = new UIEdgeInsets(10f, 10f, 10f, 10f);

				Target.InsertSubview(BackgroundImageView, 0);

				Initialized = true;
			}
		}

		/// <summary>
		/// Gets the background image view.
		/// </summary>
		/// <value>The background image view.</value>
		UIImageView BackgroundImageView {
			get;
		} = new UIImageView() {
			ContentMode = UIViewContentMode.ScaleAspectFill,
			Alpha = 0.2f
		};

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		TextArea Source {
			get {
				return Element as TextArea;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UITextView Target {
			get {
				return Control;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="UnidosPerderemos.iOS.Renderers.Controls.TextAreaRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		} = false;
	}
}