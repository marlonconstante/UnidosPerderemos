using System;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public class UnderlineTextField : Entry
	{
		/// <summary>
		/// The max length property.
		/// </summary>
		public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create<UnderlineTextField, int>(p => p.MaxLength, -1);

		/// <summary>
		/// The font property.
		/// </summary>
		public static readonly BindableProperty FontProperty = BindableProperty.Create<UnderlineTextField, Font>(p => p.Font, Font.OfSize("Roboto-Regular", 46));

		/// <summary>
		/// The bottom line color property.
		/// </summary>
		public static readonly BindableProperty BottomLineColorProperty = BindableProperty.Create<UnderlineTextField, Color>(p => p.BottomLineColor, Color.FromHex("fcff00"));

		/// <summary>
		/// The bottom line height property.
		/// </summary>
		public static readonly BindableProperty BottomLineHeightProperty = BindableProperty.Create<UnderlineTextField, double>(p => p.BottomLineHeight, 2d);

		public UnderlineTextField()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			HeightRequest = Font.FontSize;
			TextColor = Color.FromHex("fafaf5");

			TextChanged += OnTextChanged;
		}

		/// <summary>
		/// Raises the text changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="ev">Event.</param>
		void OnTextChanged(object sender, TextChangedEventArgs ev)
		{
			if (MaxLength >= 0 && Text.Length > MaxLength)
			{
				Text = Text.Substring(0, MaxLength);
			}
		}

		/// <summary>
		/// Gets or sets the length of the max.
		/// </summary>
		/// <value>The length of the max.</value>
		public int MaxLength {
			get {
				return (int) GetValue(MaxLengthProperty);
			}
			set {
				SetValue(MaxLengthProperty, value);
			}
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
		/// Gets or sets the color of the bottom line.
		/// </summary>
		/// <value>The color of the bottom line.</value>
		public Color BottomLineColor {
			get {
				return (Color) GetValue(BottomLineColorProperty);
			}
			set {
				SetValue(BottomLineColorProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the height of the bottom line.
		/// </summary>
		/// <value>The height of the bottom line.</value>
		public double BottomLineHeight {
			get {
				return (double) GetValue(BottomLineHeightProperty);
			}
			set {
				SetValue(BottomLineHeightProperty, value);
			}
		}
	}
}