using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Views.Tactic;
using UnidosPerderemos.Models;
using UnidosPerderemos.Services;
using UnidosPerderemos.Utils;

namespace UnidosPerderemos.Views.Goal
{
	public class GoalPage : ContentPage, IControlPage
	{
		public GoalPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10d,
					Padding = new Thickness(16d),
					Children = {
						DefineGoalsBox,
						LabelQuestionWeight,
						InputWeight,
						LabelQuestionTime,
						InputTime,
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
		}

		/// <summary>
		/// Raises the continue clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async void OnContinueClicked(object sender, EventArgs args)
		{
			UserProfile.GoalWeight = InputWeight.Text.ParseDouble();
			UserProfile.GoalTime = InputTime.Text.ParseDouble();

			await Navigation.PushAsync(new TacticPage());
		}

		/// <summary>
		/// Gets the define goals box.
		/// </summary>
		/// <value>The define goals box.</value>
		StackLayout DefineGoalsBox {
			get {
				return new StackLayout {
					Padding = new Thickness(0d, 37d, 0d, 17d),
					Children = {
						new CompressedLabel {
							Font = Font.OfSize("Roboto-ThinItalic", 40),
							TextColor = Color.FromHex("fcff00"),
							Text = "VAMOS DEFINIR SUAS METAS?"
						}
					}
				};
			}
		}

		/// <summary>
		/// Gets the label question weight.
		/// </summary>
		/// <value>The label question weight.</value>
		CompressedLabel LabelQuestionWeight {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-Thin", 26),
					Text = "Quantos quilos você deseja perder?"
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
			Font = Font.OfSize("Roboto-Regular", 46),
			AdditionalFont = Font.OfSize("Roboto-Light", 28),
			AdditionalText = "Quilos",
			AdditionalTranslationY = 1.5d,
			AdditionalTranslationX = 30.91d,
			Placeholder = "0",
			MaxLength = 4,
			Keyboard = Keyboard.Numeric,
			Padding = new Thickness(0d, 1d, 0d, 20d)
		};

		/// <summary>
		/// Gets the label question time.
		/// </summary>
		/// <value>The label question time.</value>
		CompressedLabel LabelQuestionTime {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-Thin", 26),
					Text = "Em quanto tempo?"
				};
			}
		}

		/// <summary>
		/// Gets the input time.
		/// </summary>
		/// <value>The input time.</value>
		UnderlineTextField InputTime {
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Regular", 46),
			AdditionalFont = Font.OfSize("Roboto-Light", 28),
			AdditionalText = "Dias",
			AdditionalTranslationY = 1.5d,
			AdditionalTranslationX = 30.91d,
			Placeholder = "0",
			MaxLength = 4,
			Keyboard = Keyboard.Numeric,
			Padding = new Thickness(0d, 1d, 0d, 34d)
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