using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class TextField : Entry
	{
		/// <summary>
		/// The max length property.
		/// </summary>
		public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create<TextField, int>(p => p.MaxLength, -1);

		/// <summary>
		/// The font property.
		/// </summary>
		public static readonly BindableProperty FontProperty = BindableProperty.Create<TextField, Font>(p => p.Font, Font.Default);

		public TextField()
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

			TextChanged += OnTextChanged;
		}

		/// <summary>
		/// Raises the text changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnTextChanged(object sender, TextChangedEventArgs args)
		{
			if (MaxLength >= 0 && Text.Length > MaxLength)
			{
				Text = Text.Substring(0, MaxLength);
			}
			else if (AfterTextChanged != null)
			{
				AfterTextChanged.Invoke(sender, args);
			}
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

				HeightRequest = value.FontSize;
			}
		}

		/// <summary>
		/// Occurs when after text changed.
		/// </summary>
		public event EventHandler<TextChangedEventArgs> AfterTextChanged;
	}
}