using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class DialogView : ContentView
	{
		public DialogView()
		{
			SetUp();

			Content = new StackLayout {
				Padding = new Thickness(0d, 10d, 0d, 0d),
				Spacing = 10d,
				Children = {
					LabelTitle,
					Separator,
					new StackLayout {
						Padding = new Thickness(10d, 0d, 10d, 0d),
						Children = {
							InnerContent
						}
					},
					GridButton
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			HorizontalOptions = LayoutOptions.Center;
			VerticalOptions = LayoutOptions.Center;
			BackgroundColor = Color.White;
			WidthRequest = 250d;

			InnerView = LabelMessage;
		}

		/// <summary>
		/// Gets the label title.
		/// </summary>
		/// <value>The label title.</value>
		Label LabelTitle {
			get;
		} = new Label {
			TextColor = Color.FromHex("59135d"),
			XAlign = TextAlignment.Center,
			FontFamily = "Roboto-LightItalic",
			FontSize = 28d
		};

		/// <summary>
		/// Gets the separator.
		/// </summary>
		/// <value>The separator.</value>
		BoxView Separator {
			get {
				return new BoxView {
					BackgroundColor = Color.FromHex("f26522"),
					HeightRequest = 1d
				};
			}
		}

		/// <summary>
		/// Gets the content of the inner.
		/// </summary>
		/// <value>The content of the inner.</value>
		ContentView InnerContent {
			get;
		} = new ContentView();

		/// <summary>
		/// Gets the grid button.
		/// </summary>
		/// <value>The grid button.</value>
		Grid GridButton {
			get {
				return new Grid {
					VerticalOptions = LayoutOptions.End,
					ColumnSpacing = 1d,
					Padding = new Thickness(0d, 1d, 0d, 0d),
					BackgroundColor = Color.FromHex("acacac"),
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					RowDefinitions = {
						new RowDefinition {
							Height = 55d
						}
					},
					Children = {
						{ ButtonCancel, 0, 0 },
						{ ButtonConfirm, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the label message.
		/// </summary>
		/// <value>The label message.</value>
		Label LabelMessage {
			get;
		} = new Label {
			TextColor = Color.FromHex("464646"),
			XAlign = TextAlignment.Center,
			FontFamily = "Roboto-Light",
			FontSize = 18d
		};

		/// <summary>
		/// Gets the button cancel.
		/// </summary>
		/// <value>The button cancel.</value>
		Button ButtonCancel {
			get;
		} = new Button {
			Text = "Cancelar",
			TextColor = Color.FromHex("157efb"),
			BackgroundColor = Color.White,
			BorderRadius = 0,
			FontFamily = "Roboto-Regular",
			FontSize = 17.5d
		};

		/// <summary>
		/// Gets the button confirm.
		/// </summary>
		/// <value>The button confirm.</value>
		Button ButtonConfirm {
			get;
		} = new Button {
			Text = "OK",
			TextColor = Color.FromHex("157efb"),
			BackgroundColor = Color.White,
			BorderRadius = 0,
			FontFamily = "Roboto-Regular",
			FontSize = 17.5d
		};

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get {
				return LabelTitle.Text;
			}
			set {
				LabelTitle.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the size of the title font.
		/// </summary>
		/// <value>The size of the title font.</value>
		public double TitleFontSize {
			get {
				return LabelTitle.FontSize;
			}
			set {
				LabelTitle.FontSize = value;
			}
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message {
			get {
				return LabelMessage.Text;
			}
			set {
				LabelMessage.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the inner view.
		/// </summary>
		/// <value>The inner view.</value>
		public View InnerView {
			get {
				return InnerContent.Content;
			}
			set {
				InnerContent.Content = value;
			}
		}

		/// <summary>
		/// Occurs when cancel clicked.
		/// </summary>
		public event EventHandler CancelClicked {
			add {
				ButtonCancel.Clicked += value;
			}
			remove {
				ButtonCancel.Clicked -= value;
			}
		}

		/// <summary>
		/// Occurs when confirm clicked.
		/// </summary>
		public event EventHandler ConfirmClicked {
			add {
				ButtonConfirm.Clicked += value;
			}
			remove {
				ButtonConfirm.Clicked -= value;
			}
		}
	}
}