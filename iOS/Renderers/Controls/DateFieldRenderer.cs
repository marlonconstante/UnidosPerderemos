using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using UnidosPerderemos.Core.Controls;
using MonoTouch.Foundation;

[assembly: ExportRenderer(typeof(DateField), typeof(UnidosPerderemos.iOS.Renderers.Controls.DateFieldRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class DateFieldRenderer : DatePickerRenderer
	{
		public DateFieldRenderer()
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
				Target.BackgroundColor = UIColor.Clear;
				Target.BorderStyle = UITextBorderStyle.None;
				Target.TextAlignment = Source.TextAlignment.ToUITextAlignment();
				Target.Font = Source.Font.ToUIFont();
				Target.TextColor = Source.TextColor.ToUIColor();
				Target.SetValueForKeyPath(Source.TextColor.ToUIColor(), new NSString("_placeholderLabel.textColor"));

				Picker.BackgroundColor = UIColor.FromRGB(242, 243, 245);

				Toolbar.BarTintColor = UIColor.FromRGB(238, 238, 238);
				Toolbar.TintColor = UIColor.FromRGB(219, 66, 80);

				Initialized = true;
			}
		}

		/// <summary>
		/// Gets the toolbar.
		/// </summary>
		/// <value>The toolbar.</value>
		UIToolbar Toolbar {
			get {
				return Target.InputAccessoryView as UIToolbar;
			}
		}

		/// <summary>
		/// Gets the picker.
		/// </summary>
		/// <value>The picker.</value>
		UIDatePicker Picker {
			get {
				return Target.InputView as UIDatePicker;
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		DateField Source {
			get {
				return Element as DateField;
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
		/// Gets or sets a value indicating whether this
		/// <see cref="UnidosPerderemos.iOS.Renderers.Controls.DateFieldRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		} = false;
	}
}