using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using System.Drawing;

[assembly: ExportRenderer(typeof(UnderlineTextField), typeof(UnidosPerderemos.iOS.UnderlineTextFieldRenderer))]
namespace UnidosPerderemos.iOS
{
	public class UnderlineTextFieldRenderer : EntryRenderer
	{
		public UnderlineTextFieldRenderer()
		{
			Initialized = false;
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
				Control.BackgroundColor = UIColor.Clear;
				Control.BorderStyle = UITextBorderStyle.None;
				Control.Font = TextField.Font.ToUIFont();
				Control.Layer.AddSublayer(BottomLine);

				Initialized = true;
			}
		}

		/// <summary>
		/// Gets the bottom line.
		/// </summary>
		/// <value>The bottom line.</value>
		CALayer BottomLine {
			get {
				var size = Control.Frame.Size;
				var lineHeight = (float) TextField.BottomLineHeight;
				return new CALayer {
					Frame = new RectangleF(0f, size.Height - lineHeight, size.Width, lineHeight),
					BackgroundColor = TextField.BottomLineColor.ToCGColor()
				};
			}
		}

		/// <summary>
		/// Gets the text field.
		/// </summary>
		/// <value>The text field.</value>
		UnderlineTextField TextField {
			get {
				return Element as UnderlineTextField;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnidosPerderemos.iOS.UnderlineTextFieldRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		}
	}
}