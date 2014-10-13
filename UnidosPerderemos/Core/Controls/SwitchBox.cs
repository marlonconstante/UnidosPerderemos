using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class SwitchBox : ContentView
	{
		public SwitchBox()
		{
			SetUp();

			Content = new Grid {
				RowDefinitions = {
					new RowDefinition {
						Height = 67d
					}
				},
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = 76d
					},
					new ColumnDefinition {
						Width = GridLength.Auto
					}
				},
				Children = {
					{ BoxSwitch, 0, 0 },
					{ Switch, 0, 0 },
					{ LabelText, 1, 0 }
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			BoxSwitch = new BoxView();

			Switch = new Switch {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			LabelText = new CompressedLabel {
				VerticalOptions = LayoutOptions.Center,
				TranslationY = 2d
			};

			BackgroundColor = Color.FromHex("fcff00").MultiplyAlpha(0.2d);
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

		/// <summary>
		/// Gets or sets a value indicating whether this instance is toggled.
		/// </summary>
		/// <value><c>true</c> if this instance is toggled; otherwise, <c>false</c>.</value>
		public bool IsToggled {
			get {
				return Switch.IsToggled;
			}
			set {
				Switch.IsToggled = value;
			}
		}

		/// <summary>
		/// Gets or sets the color which will fill the background of a VisualElement. This is a bindable property.
		/// </summary>
		/// <value>The color of the background.</value>
		public Color BackgroundColor {
			get {
				return base.BackgroundColor;
			}
			set {
				base.BackgroundColor = value;

				BoxSwitch.BackgroundColor = value;
			}
		}

		/// <summary>
		/// Gets the box switch.
		/// </summary>
		/// <value>The box switch.</value>
		public BoxView BoxSwitch {
			get;
			private set;
		}

		/// <summary>
		/// Gets the switch.
		/// </summary>
		/// <value>The switch.</value>
		public Switch Switch {
			get;
			private set;
		}

		/// <summary>
		/// Gets the label text.
		/// </summary>
		/// <value>The label text.</value>
		public CompressedLabel LabelText {
			get;
			private set;
		}
	}
}