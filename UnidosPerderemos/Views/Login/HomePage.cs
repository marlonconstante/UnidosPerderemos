using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.Login
{
	public class HomePage : ContentPage, IControlPage
	{
		public HomePage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new Grid {
					RowSpacing = 0d,
					Padding = new Thickness(16d, 30d, 16d, 0d),
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					RowDefinitions = {
						new RowDefinition {
							Height = new GridLength(1d, GridUnitType.Star)
						},
						new RowDefinition {
							Height = new GridLength(0.7d, GridUnitType.Star)
						}
					},
					Children = {
						{ LogoBox, 0, 0 },
						{ ButtonBox, 0, 1 }
					}
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			BackgroundImage = "BackgroundGoal.png";
		}

		/// <summary>
		/// Gets the logo box.
		/// </summary>
		/// <value>The logo box.</value>
		StackLayout LogoBox {
			get {
				return new StackLayout {
					VerticalOptions = LayoutOptions.End,
					Spacing = 30d,
					Children = {
						Logo,
						LabelName
					}
				};
			}
		}

		/// <summary>
		/// Gets the button box.
		/// </summary>
		/// <value>The button box.</value>
		StackLayout ButtonBox {
			get {
				return new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Spacing = 4d,
					Children = {
						ButtonSignUp,
						ButtonLogin
					}
				};
			}
		}

		/// <summary>
		/// Gets the logo.
		/// </summary>
		/// <value>The logo.</value>
		Image Logo {
			get;
		} = new Image {
			Source = ImageSource.FromFile("Logo.png"),
			WidthRequest = 125.5d,
			HeightRequest = 172d
		};

		/// <summary>
		/// Gets the name of the label.
		/// </summary>
		/// <value>The name of the label.</value>
		CompressedLabel LabelName {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("TisaSansPro-Italic", 34),
			TextColor = Color.FromHex("fdffff"),
			Text = "Unidos Perderemos",
			XAlign = TextAlignment.Center
		};

		/// <summary>
		/// Gets the button sign up.
		/// </summary>
		/// <value>The button sign up.</value>
		GhostButton ButtonSignUp {
			get;
		} = new GhostButton {
			Text = "REGISTRAR",
			HeightRequest = 67d
		};

		/// <summary>
		/// Gets the button login.
		/// </summary>
		/// <value>The button login.</value>
		ImageButton ButtonLogin {
			get;
		} = new ImageButton {
			Image = ImageSource.FromFile("User.png") as FileImageSource,
			Font = Font.OfSize("Roboto-Light", 19),
			TextColor = Color.FromHex("fcfcfc"),
			Text = "Já tenho uma conta"
		};

		/// <summary>
		/// Preferreds the status bar style.
		/// </summary>
		/// <returns>The status bar style.</returns>
		public StatusBarStyle PreferredStatusBarStyle()
		{
			return StatusBarStyle.Light;
		}

		/// <summary>
		/// Determines whether this instance is show navigation bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show navigation bar; otherwise, <c>false</c>.</returns>
		public bool IsShowNavigationBar()
		{
			return false;
		}

		/// <summary>
		/// Determines whether this instance is show status bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show status bar; otherwise, <c>false</c>.</returns>
		public bool IsShowStatusBar()
		{
			return true;
		}
	}
}