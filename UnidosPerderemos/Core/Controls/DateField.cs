using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class DateField : DatePicker
	{
		/// <summary>
		/// The font property.
		/// </summary>
		public static readonly BindableProperty FontProperty = BindableProperty.Create<DateField, Font>(p => p.Font, Font.Default);

		/// <summary>
		/// The text color property.
		/// </summary>
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<DateField, Color>(p => p.TextColor, Color.Default);

		public DateField()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Font = Font.OfSize("Roboto-Regular", 20);
			TextColor = Color.FromHex("fafaf5");
			Format = "d 'de' MMMMM 'de' yyyy";
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

				HeightRequest = value.FontSize;
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