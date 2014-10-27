using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class UnderlineDateField : ContentBottomLine
	{
		public UnderlineDateField()
		{
			SetUp();

			Content = new StackLayout {
				Spacing = 4d,
				Children = {
					DateField,
					BoxBottomLine
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			DateField = new DateField();
		}

		/// <summary>
		/// Gets the date field.
		/// </summary>
		/// <value>The date field.</value>
		public DateField DateField {
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the desired height override of this element.
		/// </summary>
		/// <value>The height this element desires to be.</value>
		/// <remarks>HeightRequest does not immediately change the Bounds of a VisualElement, however setting the HeightRequest will
		/// change the result of calls to GetSizeRequest, which will in turn modify the final size the element receives during
		/// a layout cycle.</remarks>
		public double HeightRequest {
			get {
				return base.HeightRequest;
			}
			set {
				base.HeightRequest = value;

				DateField.HeightRequest = value - BottomLineHeight;
			}
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date {
			get {
				return DateField.Date;
			}
			set {
				DateField.Date = value;
			}
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get {
				return DateField.Font;
			}
			set {
				DateField.Font = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor {
			get {
				return DateField.TextColor;
			}
			set {
				DateField.TextColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the format.
		/// </summary>
		/// <value>The format.</value>
		public string Format {
			get {
				return DateField.Format;
			}
			set {
				DateField.Format = value;
			}
		}

		/// <summary>
		/// Gets or sets the maximum date.
		/// </summary>
		/// <value>The maximum date.</value>
		public DateTime MaximumDate {
			get {
				return DateField.MaximumDate;
			}
			set {
				DateField.MaximumDate = value;
			}
		}

		/// <summary>
		/// Gets or sets the minimum date.
		/// </summary>
		/// <value>The minimum date.</value>
		public DateTime MinimumDate {
			get {
				return DateField.MinimumDate;
			}
			set {
				DateField.MinimumDate = value;
			}
		}
	}
}