﻿using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.About
{
	public class AboutPage : ContentPage, IControlPage
	{
		public AboutPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 25d,
					Padding = new Thickness(16d),
					Children = {
						AboutYouBox,
						LabelDateOfBirth,
						InputDateOfBirth,
						LabelGender,
						LabelWeight,
						InputWeight,
						LabelHeight,
						InputHeight,
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
		/// Gets the about you box.
		/// </summary>
		/// <value>The about you box.</value>
		StackLayout AboutYouBox {
			get {
				return new StackLayout {
					Padding = new Thickness(0d, 22d, 0d, -14d),
					Children = {
						new CompressedLabel {
							Font = Font.OfSize("Roboto-ThinItalic", 40),
							TextColor = Color.FromHex("fcff00"),
							Text = "SOBRE VOCÊ"
						}
					}
				};
			}
		}

		/// <summary>
		/// Gets the label date of birth.
		/// </summary>
		/// <value>The label date of birth.</value>
		IconLabel LabelDateOfBirth {
			get {
				return new IconLabel {
					Image = ImageSource.FromFile("Calendar.png"),
					Font = Font.OfSize("Roboto-Thin", 26),
					Text = "Data de nascimento"
				};
			}
		}

		/// <summary>
		/// Gets the input date of birth.
		/// </summary>
		/// <value>The input date of birth.</value>
		UnderlineDateField InputDateOfBirth {
			get {
				return new UnderlineDateField {
					Font = Font.OfSize("Roboto-Light", 25),
					Padding = new Thickness(0d, -20d, 0d, -3d),
					HeightRequest = 35d
				};
			}
		}

		/// <summary>
		/// Gets the label gender.
		/// </summary>
		/// <value>The label gender.</value>
		IconLabel LabelGender {
			get {
				return new IconLabel {
					Image = ImageSource.FromFile("Gender.png"),
					Font = Font.OfSize("Roboto-Thin", 26),
					Text = "Sexo"
				};
			}
		}

		/// <summary>
		/// Gets the label weight.
		/// </summary>
		/// <value>The label weight.</value>
		IconLabel LabelWeight {
			get {
				return new IconLabel {
					Image = ImageSource.FromFile("Balance.png"),
					Font = Font.OfSize("Roboto-Thin", 26),
					Text = "Peso atual"
				};
			}
		}

		/// <summary>
		/// Gets the input weight.
		/// </summary>
		/// <value>The input weight.</value>
		UnderlineTextField InputWeight {
			get {
				return new UnderlineTextField {
					Font = Font.OfSize("Roboto-Regular", 41),
					AdditionalFont = Font.OfSize("Roboto-Light", 28),
					AdditionalText = "Quilos",
					AdditionalTranslationY = 3.5d,
					Text = "0",
					MaxLength = 4,
					Keyboard = Keyboard.Numeric,
					Padding = new Thickness(0d, -23d, 0d, -7d)
				};
			}
		}

		/// <summary>
		/// Gets the height of the label.
		/// </summary>
		/// <value>The height of the label.</value>
		IconLabel LabelHeight {
			get {
				return new IconLabel {
					Image = ImageSource.FromFile("Ruler.png"),
					Font = Font.OfSize("Roboto-Thin", 26),
					Text = "Altura"
				};
			}
		}

		/// <summary>
		/// Gets the height of the input.
		/// </summary>
		/// <value>The height of the input.</value>
		UnderlineTextField InputHeight {
			get {
				return new UnderlineTextField {
					Font = Font.OfSize("Roboto-Regular", 41),
					AdditionalFont = Font.OfSize("Roboto-Light", 28),
					AdditionalText = "Metros",
					AdditionalTranslationY = 3.5d,
					Text = "0",
					MaxLength = 4,
					Keyboard = Keyboard.Numeric,
					Padding = new Thickness(0d, -23d, 0d, -7d)
				};
			}
		}

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