using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.Daily
{
	public class ActivityTodayViewBox : ContentView
	{
		public ActivityTodayViewBox()
		{
			Content = new StackLayout {
				Spacing = 0d,
				Padding = new Thickness(0d),
				Children = {
					GridHeader,
					Separator,
					InputText,
					Separator
				}
			};
		}

		/// <summary>
		/// Gets the grid header.
		/// </summary>
		/// <value>The grid header.</value>
		Grid GridHeader {
			get {
				return new Grid {
					ColumnSpacing = 0d,
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = 50d
						}
					},
					Children = {
						{ LabelText, 0, 0 },
						{ CameraButton, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the separator.
		/// </summary>
		/// <value>The separator.</value>
		BoxView Separator {
			get {
				return new BoxView {
					BackgroundColor = Color.FromHex("fcff00"),
					HeightRequest = 1d
				};
			}
		}

		/// <summary>
		/// Gets the input text.
		/// </summary>
		/// <value>The input text.</value>
		TextArea InputText {
			get {
				return new TextArea {
					Text = "Conte como foi o seu dia"
				};
			}
		}

		/// <summary>
		/// Gets the label text.
		/// </summary>
		/// <value>The label text.</value>
		CompressedLabel LabelText {
			get {
				return new CompressedLabel {
					TranslationX = 15d,
					YAlign = TextAlignment.Center,
					Font = Font.OfSize("Roboto-ThinItalic", 27),
					TextColor = Color.FromHex("fcff00"),
					Text = "O que você fez hoje?"
				};
			}
		}

		/// <summary>
		/// Gets the camera button.
		/// </summary>
		/// <value>The camera button.</value>
		ImageButton CameraButton {
			get {
				return new ImageButton {
					TranslationX = 5d,
					Image = ImageSource.FromFile("Camera.png") as FileImageSource
				};
			}
		}
	}
}