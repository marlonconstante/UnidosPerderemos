using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Views.Goal;
using UnidosPerderemos.Models;
using System.Collections.Generic;

namespace UnidosPerderemos.Views.About
{
	public class AboutPage : ContentPage, IControlPage
	{
		public AboutPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 22d,
					Padding = new Thickness(16d),
					Children = {
						AboutYouBox,
						DateOfBirthBox,
						GenderBox,
						WeightBox,
						HeightBox,
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
			ButtonContinue.Clicked += OnContinueClicked;

			InputGender.Items = GenderInfo.GetGenderItems();
			InputGender.SelectedItem = App.Instance.CurrentUser.Gender;
		}

		/// <summary>
		/// Raises the continue clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async void OnContinueClicked(object sender, EventArgs args)
		{
			await App.Instance.LoadUserProfile();

			UserProfile.DateOfBirth = InputDateOfBirth.Date;
			UserProfile.Gender = (Gender) InputGender.SelectedItem;
			UserProfile.Weight = double.Parse(InputWeight.Text);
			UserProfile.Height = double.Parse(InputHeight.Text);

			await Navigation.PushAsync(new GoalPage());
		}

		/// <summary>
		/// Gets the about you box.
		/// </summary>
		/// <value>The about you box.</value>
		StackLayout AboutYouBox {
			get {
				return new StackLayout {
					Padding = new Thickness(0d, 19d, 0d, -10d),
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
		/// Gets the date of birth box.
		/// </summary>
		/// <value>The date of birth box.</value>
		StackLayout DateOfBirthBox {
			get {
				return new StackLayout {
					Spacing = 1d,
					Children = {
						LabelDateOfBirth,
						InputDateOfBirth
					}
				};
			}
		}

		/// <summary>
		/// Gets the gender box.
		/// </summary>
		/// <value>The gender box.</value>
		StackLayout GenderBox {
			get {
				return new StackLayout {
					Spacing = 6d,
					Children = {
						LabelGender,
						InputGender
					}
				};
			}
		}

		/// <summary>
		/// Gets the weight box.
		/// </summary>
		/// <value>The weight box.</value>
		StackLayout WeightBox {
			get {
				return new StackLayout {
					Spacing = 0d,
					Children = {
						LabelWeight,
						InputWeight
					}
				};
			}
		}

		/// <summary>
		/// Gets the height box.
		/// </summary>
		/// <value>The height box.</value>
		StackLayout HeightBox {
			get {
				return new StackLayout {
					Spacing = 0d,
					Children = {
						LabelHeight,
						InputHeight
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
			get;
		} = new UnderlineDateField {
			Font = Font.OfSize("Roboto-Light", 25),
			HeightRequest = 35d
		};

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
		/// Gets the input gender.
		/// </summary>
		/// <value>The input gender.</value>
		OptionButton InputGender {
			get;
		} = new OptionButton();

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
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Regular", 41),
			AdditionalFont = Font.OfSize("Roboto-Light", 28),
			AdditionalText = "Quilos",
			AdditionalTranslationY = 3.5d,
			Text = "0",
			MaxLength = 4,
			Keyboard = Keyboard.Numeric
		};

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
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Regular", 41),
			AdditionalFont = Font.OfSize("Roboto-Light", 28),
			AdditionalText = "Metros",
			AdditionalTranslationY = 3.5d,
			Text = "0",
			MaxLength = 4,
			Keyboard = Keyboard.Numeric
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
		/// Gets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get {
				return App.Instance.CurrentUserProfile;
			}
		}

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

		/// <summary>
		/// Backgrounds the name of the image.
		/// </summary>
		/// <returns>The image name.</returns>
		public string BackgroundImageName()
		{
			return "Background-2.jpg";
		}
	}
}