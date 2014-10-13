using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using System.Drawing;
using UnidosPerderemos.Core.Controls;

[assembly: ExportRenderer(typeof(TextField), typeof(UnidosPerderemos.iOS.TextFieldRenderer))]
namespace UnidosPerderemos.iOS
{
	public class TextFieldRenderer : EntryRenderer
	{
		public TextFieldRenderer()
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
				Target.BackgroundColor = UIColor.Clear;
				Target.BorderStyle = UITextBorderStyle.None;
				Target.Font = Source.Font.ToUIFont();

				Initialized = true;
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		TextField Source {
			get {
				return Element as TextField;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UITextField Target {
			get {
				return Control;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnidosPerderemos.iOS.TextFieldRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		}
	}
}