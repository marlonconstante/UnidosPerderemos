using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos;
using MonoTouch.UIKit;
using UnidosPerderemos.Core.Controls;
using MonoTouch.CoreAnimation;
using System.Drawing;

[assembly: ExportRenderer(typeof(TextArea), typeof(UnidosPerderemos.iOS.Renderers.Controls.TextAreaRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class TextAreaRenderer : EditorRenderer
	{
		public TextAreaRenderer()
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
				Target.Font = Source.Font.ToUIFont();
				Target.TextColor = Source.TextColor.ToUIColor();
				Target.TextContainerInset = new UIEdgeInsets(10f, 10f, 10f, 10f);

				Initialized = true;
			}
		}

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