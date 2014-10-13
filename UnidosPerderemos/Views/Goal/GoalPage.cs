using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos
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
						LabelDefineGoals,
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
			BackgroundImage = "BackgroundGoal.png";

			ButtonContinue.Clicked += OnContinueClicked;
		}

		/// <summary>
		/// Raises the continue clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnContinueClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync(new TacticPage());
		}

		/// <summary>
		/// Gets the label define goals.
		/// </summary>
		/// <value>The label define goals.</value>
		CompressedLabel LabelDefineGoals {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-ThinItalic", 40),
					TextColor = Color.FromHex("fcff00"),
					Text = "VAMOS DEFINIR\nSUAS METAS?",
					TranslationY = 37d,
					HeightRequest = 140d
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
					Text = "Quantos quilos você\ndeseja perder?"
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
					Font = Font.OfSize("Roboto-Regular", 46),
					AdditionalFont = Font.OfSize("Roboto-Light", 28),
					AdditionalText = "Quilos",
					AdditionalTranslationY = 1.5d,
					Text = "0",
					MaxLength = 4,
					Keyboard = Keyboard.Numeric,
					Padding = new Thickness(0d, 1d, 0d, 20d)
				};
			}
		}

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
			get {
				return new UnderlineTextField {
					Font = Font.OfSize("Roboto-Regular", 46),
					AdditionalFont = Font.OfSize("Roboto-Light", 28),
					AdditionalText = "Dias",
					AdditionalTranslationY = 1.5d,
					Text = "0",
					MaxLength = 4,
					Keyboard = Keyboard.Numeric,
					Padding = new Thickness(0d, 1d, 0d, 34d)
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