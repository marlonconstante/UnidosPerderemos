using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class TextArea : Editor
	{
		/// <summary>
		/// The font property.
		/// </summary>
		public static readonly BindableProperty FontProperty = BindableProperty.Create<TextArea, Font>(p => p.Font, Font.Default);

		/// <summary>
		/// The text color property.
		/// </summary>
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<TextArea, Color>(p => p.TextColor, Color.Default);

		public TextArea()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Font = Font.OfSize("Roboto-Light", 23);
			TextColor = Color.FromHex("fcfcfa");
			BackgroundColor = Color.White.MultiplyAlpha(0.1d);
			HeightRequest = 127d;
		}

		/// <summary>
		/// Requests the focus.
		/// </summary>
		public void RequestFocus()
		{
			Device.BeginInvokeOnMainThread(() => {
				Focus();
			});
		}

		/// <summary>
		/// Requests the unfocus.
		/// </summary>
		public void RequestUnfocus()
		{
			Device.BeginInvokeOnMainThread(() => {
				Unfocus();
			});
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get {
				return (Font) GetValue(FontProperty);
			}
			set {
				SetValue(FontProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor {
			get {
				return (Color) GetValue(TextColorProperty);
			}
			set {
				SetValue(TextColorProperty, value);
			}
		}
	}
}