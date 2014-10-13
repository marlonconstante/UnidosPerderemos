using System;
using UnidosPerderemos;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;

[assembly: ExportRenderer(typeof(CompressedLabel), typeof(UnidosPerderemos.iOS.Renderers.Controls.CompressedLabelRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class CompressedLabelRenderer : LabelRenderer
	{
		public CompressedLabelRenderer()
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
				UpdateLineHeight();

				Initialized = true;
			}
		}

		/// <summary>
		/// Updates the height of the line.
		/// </summary>
		void UpdateLineHeight()
		{
			var lineHeight = (float) Source.Font.FontSize;
			var spacing = lineHeight * 0.15f;

			var style = new NSMutableParagraphStyle();
			style.MinimumLineHeight = lineHeight + spacing;
			style.MaximumLineHeight = lineHeight + spacing;
			style.LineSpacing = -spacing;
			style.ParagraphSpacing = -spacing;

			var attributedString = new NSMutableAttributedString(Target.AttributedText);
			attributedString.AddAttribute(new NSString("NSParagraphStyle"), style, new NSRange(0, attributedString.Length));

			Target.AttributedText = attributedString;
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		CompressedLabel Source {
			get {
				return Element as CompressedLabel;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UILabel Target {
			get {
				return Control;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnidosPerderemos.iOS.CompressedLabelRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		}
	}
}