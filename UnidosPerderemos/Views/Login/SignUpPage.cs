using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Views.About;

namespace UnidosPerderemos.Views.Login
{
	public class SignUpPage : ContentPage, IControlPage
	{
		public SignUpPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 25d,
					Padding = new Thickness(16d),
					Children = {
						WelcomeBox,
						FacebookButton,
						LabelRegisterManually,
						InputName,
						InputEmail,
						InputPassword,
						ButtonContinue
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

			FacebookButton.Clicked += OnContinueClicked;
			ButtonContinue.Clicked += OnContinueClicked;
		}

		/// <summary>
		/// Raises the continue clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnContinueClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync(new AboutPage());
		}

		/// <summary>
		/// Gets the welcome box.
		/// </summary>
		/// <value>The welcome box.</value>
		StackLayout WelcomeBox {
			get {
				return new StackLayout {
					Padding = new Thickness(0d, 25d, 0d, 1d),
					Children = {
						new CompressedLabel {
							Font = Font.OfSize("Roboto-ThinItalic", 40),
							TextColor = Color.FromHex("fcff00"),
							Text = "SEJA BEM-VINDO!"
						}
					}
				};
			}
		}

		/// <summary>
		/// Gets the facebook button.
		/// </summary>
		/// <value>The facebook button.</value>
		FacebookButton FacebookButton {
			get;
		} = new FacebookButton {
			Text = "REGISTRAR COM FACEBOOK",
			HeightRequest = 55d
		};

		/// <summary>
		/// Gets the label register manually.
		/// </summary>
		/// <value>The label register manually.</value>
		CompressedLabel LabelRegisterManually {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-Thin", 20),
					TextColor = Color.FromHex("fafaf5"),
					Text = "ou registre-se manualmente",
					XAlign = TextAlignment.Center
				}; 
			}
		}

		/// <summary>
		/// Gets the name of the input.
		/// </summary>
		/// <value>The name of the input.</value>
		UnderlineTextField InputName {
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Light", 28),
			Placeholder = "Nome",
			HeightRequest = 36d
		};

		/// <summary>
		/// Gets the input email.
		/// </summary>
		/// <value>The input email.</value>
		UnderlineTextField InputEmail {
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Light", 28),
			Keyboard = Keyboard.Email,
			Placeholder = "E-mail",
			HeightRequest = 36d
		};

		/// <summary>
		/// Gets the input password.
		/// </summary>
		/// <value>The input password.</value>
		UnderlineTextField InputPassword {
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Light", 28),
			Padding = new Thickness(0d, 0d, 0d, 7d),
			Placeholder = "Senha",
			IsPassword = true,
			HeightRequest = 36d
		};

		/// <summary>
		/// Gets the button continue.
		/// </summary>
		/// <value>The button continue.</value>
		GhostButton ButtonContinue {
			get;
		} = new GhostButton {
			Text = "CONTINUAR",
			HeightRequest = 67d
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