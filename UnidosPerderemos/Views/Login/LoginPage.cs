﻿using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.Login
{
	public class LoginPage : ContentPage, IControlPage
	{
		public LoginPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 25d,
					Padding = new Thickness(16d),
					Children = {
						EnterMyAccountBox,
						FacebookButton,
						LabelEnterManually,
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
		}

		/// <summary>
		/// Gets the enter my account box.
		/// </summary>
		/// <value>The enter my account box.</value>
		StackLayout EnterMyAccountBox {
			get {
				return new StackLayout {
					Padding = new Thickness(0d, 25d, 0d, 1d),
					Children = {
						new CompressedLabel {
							Font = Font.OfSize("Roboto-ThinItalic", 40),
							TextColor = Color.FromHex("fcff00"),
							Text = "ENTRAR NA MINHA CONTA"
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
			Text = "ENTRAR COM FACEBOOK",
			HeightRequest = 55d
		};

		/// <summary>
		/// Gets the label enter manually.
		/// </summary>
		/// <value>The label enter manually.</value>
		CompressedLabel LabelEnterManually {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-Thin", 20),
					TextColor = Color.FromHex("fafaf5"),
					Text = "ou entre manualmente",
					XAlign = TextAlignment.Center
				}; 
			}
		}

		/// <summary>
		/// Gets the input email.
		/// </summary>
		/// <value>The input email.</value>
		UnderlineTextField InputEmail {
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Light", 28),
			Padding = new Thickness(0d, 12d, 0d, 0d),
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
			Padding = new Thickness(0d, 0d, 0d, 33d),
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