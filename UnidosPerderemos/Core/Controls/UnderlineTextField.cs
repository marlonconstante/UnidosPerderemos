using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Core.Controls
{
	public class UnderlineTextField : ContentBottomLine
	{
		public UnderlineTextField()
		{
			SetUp();

			Content = new StackLayout {
				Children = {
					new Grid {
						ColumnDefinitions = {
							new ColumnDefinition {
								Width = new GridLength(1d, GridUnitType.Star)
							}
						},
						Children = {
							TextField,
							LabelAdditional
						}
					},
					BoxBottomLine
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			TextField = new TextField();
			TextField.AfterTextChanged += OnAfterTextChanged;

			LabelAdditional = new CompressedLabel {
				TextColor = TextColor,
				VerticalOptions = LayoutOptions.End
			};
			AddTappedAdditional();
		}

		/// <summary>
		/// Adds the tapped additional.
		/// </summary>
		void AddTappedAdditional()
		{
			var gestureRecognizer = new TapGestureRecognizer();
			gestureRecognizer.Tapped += OnTappedAdditional;
			LabelAdditional.GestureRecognizers.Add(gestureRecognizer);
		}

		/// <summary>
		/// Raises the tapped additional event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnTappedAdditional(object sender, EventArgs args)
		{
			TextField.RequestFocus();
		}

		/// <summary>
		/// Raises the after text changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnAfterTextChanged(object sender, TextChangedEventArgs args)
		{
			var width = DependencyService.Get<ITextService>().PreferredSize(Text, Font, Size.Zero).Width;
			LabelAdditional.TranslationX = width + (string.IsNullOrWhiteSpace(Text) ? InitialAdditionalX : 5d);
		}

		/// <summary>
		/// Gets the text field.
		/// </summary>
		/// <value>The text field.</value>
		public TextField TextField {
			get;
			private set;
		}

		/// <summary>
		/// Gets the label additional.
		/// </summary>
		/// <value>The label additional.</value>
		public CompressedLabel LabelAdditional {
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

				TextField.HeightRequest = value - BottomLineHeight;
			}
		}

		/// <summary>
		/// Gets or sets the length of the max.
		/// </summary>
		/// <value>The length of the max.</value>
		public int MaxLength {
			get {
				return TextField.MaxLength;
			}
			set {
				TextField.MaxLength = value;
			}
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get {
				return TextField.Font;
			}
			set {
				TextField.Font = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is password.
		/// </summary>
		/// <value><c>true</c> if this instance is password; otherwise, <c>false</c>.</value>
		public bool IsPassword {
			get {
				return TextField.IsPassword;
			}
			set {
				TextField.IsPassword = value;
			}
		}

		/// <summary>
		/// Gets or sets the placeholder.
		/// </summary>
		/// <value>The placeholder.</value>
		public string Placeholder {
			get {
				return TextField.Placeholder;
			}
			set {
				TextField.Placeholder = value;
			}
		}

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public string Text {
			get {
				return TextField.Text;
			}
			set {
				TextField.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor {
			get {
				return TextField.TextColor;
			}
			set {
				TextField.TextColor = value;

				LabelAdditional.TextColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the keyboard.
		/// </summary>
		/// <value>The keyboard.</value>
		public Keyboard Keyboard {
			get {
				return TextField.Keyboard;
			}
			set {
				TextField.Keyboard = value;
			}
		}

		/// <summary>
		/// Gets or sets the additional text.
		/// </summary>
		/// <value>The additional text.</value>
		public string AdditionalText {
			get {
				return LabelAdditional.Text;
			}
			set {
				LabelAdditional.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the additional font.
		/// </summary>
		/// <value>The additional font.</value>
		public Font AdditionalFont {
			get {
				return LabelAdditional.Font;
			}
			set {
				LabelAdditional.Font = value;
			}
		}

		/// <summary>
		/// Gets or sets the additional translation y.
		/// </summary>
		/// <value>The additional translation y.</value>
		public double AdditionalTranslationY {
			get {
				return LabelAdditional.TranslationY;
			}
			set {
				LabelAdditional.TranslationY = value;
			}
		}

		/// <summary>
		/// Gets or sets the additional translation x.
		/// </summary>
		/// <value>The additional translation x.</value>
		public double AdditionalTranslationX {
			get {
				return LabelAdditional.TranslationX;
			}
			set {
				LabelAdditional.TranslationX = value;

				if (InitialAdditionalX == 0d)
				{
					InitialAdditionalX = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the initial additional x.
		/// </summary>
		/// <value>The initial additional x.</value>
		double InitialAdditionalX {
			get;
			set;
		}
	}
}