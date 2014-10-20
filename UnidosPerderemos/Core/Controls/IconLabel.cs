using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class IconLabel : ContentView
	{
		public IconLabel()
		{
			Content = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = 24d
					},
					new ColumnDefinition {
						Width = new GridLength(1d, GridUnitType.Star)
					}
				},
				Children = {
					{ Icon, 0, 0 },
					{ LabelText, 1, 0 }
				}
			};
		}

		/// <summary>
		/// Gets the icon.
		/// </summary>
		/// <value>The icon.</value>
		Image Icon {
			get;
		} = new Image {
			VerticalOptions = LayoutOptions.Start,
			TranslationY = 2.5d
		};

		/// <summary>
		/// Gets the label text.
		/// </summary>
		/// <value>The label text.</value>
		CompressedLabel LabelText {
			get;
		} = new CompressedLabel();

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>The image.</value>
		public ImageSource Image {
			get {
				return Icon.Source;
			}
			set {
				Icon.Source = value;
			}
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get {
				return LabelText.Font;
			}
			set {
				LabelText.Font = value;
			}
		}

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public string Text {
			get {
				return LabelText.Text;
			}
			set {
				LabelText.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor {
			get {
				return LabelText.TextColor;
			}
			set {
				LabelText.TextColor = value;
			}
		}
	}
}