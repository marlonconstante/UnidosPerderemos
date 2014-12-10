using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos;
using MonoTouch.UIKit;
using UnidosPerderemos.Core.Controls;
using MonoTouch.Foundation;
using System.Drawing;

[assembly: ExportRenderer(typeof(TextField), typeof(UnidosPerderemos.iOS.Renderers.Controls.TextFieldRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class TextFieldRenderer : EntryRenderer
	{
		public TextFieldRenderer()
		{
		}

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> args)
		{
			base.OnElementChanged(args);

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
				Target.SetValueForKeyPath(Source.TextColor.ToUIColor(), new NSString("_placeholderLabel.textColor"));

				AddDoneButton();

				Initialized = true;
			}
		}

		/// <summary>
		/// Adds the done button.
		/// </summary>
		void AddDoneButton()
		{
			Toolbar.Items = new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
					Target.ResignFirstResponder();
				})
			};

			Target.InputAccessoryView = Toolbar;
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
		/// Gets the toolbar.
		/// </summary>
		/// <value>The toolbar.</value>
		UIToolbar Toolbar {
			get;
		} = new UIToolbar(new RectangleF(0f, 0f, 0f, 44f));

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
		/// <see cref="UnidosPerderemos.iOS.Renderers.Controls.TextFieldRenderer"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		} = false;
	}
}