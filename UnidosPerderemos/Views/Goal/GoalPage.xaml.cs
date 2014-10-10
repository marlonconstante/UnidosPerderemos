using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public partial class GoalPage : ContentPage
	{
		public GoalPage()
		{
			InitializeComponent();

			BackgroundImage = "BackgroundGoal.png";

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
		/// Gets the label define goals.
		/// </summary>
		/// <value>The label define goals.</value>
		CompressedLabel LabelDefineGoals {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-ThinItalic", 40),
					TextColor = Color.FromHex("fcff00"),
					Text = "VAMOS DEFINIR\nSUAS METAS?",
					TranslationY = 42d,
					HeightRequest = 144d
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
					Text = "0",
					MaxLength = 4,
					Keyboard = Keyboard.Numeric,
					Padding = new Thickness(0d, 1d, 0d, 37d)
				};
			}
		}

		/// <summary>
		/// Gets the button continue.
		/// </summary>
		/// <value>The button continue.</value>
		GhostButton ButtonContinue {
			get {
				return new GhostButton {
					Text = "CONTINUAR",
					HeightRequest = 67d
				};
			}
		}
	}
}