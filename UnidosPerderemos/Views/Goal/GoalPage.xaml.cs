﻿using System;
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
		Label LabelDefineGoals {
			get {
				return new Label {
					Font = Font.OfSize("Roboto-ThinItalic", 40),
					TextColor = Color.FromHex("fcff00"),
					Text = "VAMOS DEFINIR\nSUAS METAS?"
				}; 
			}
		}

		/// <summary>
		/// Gets the label question weight.
		/// </summary>
		/// <value>The label question weight.</value>
		Label LabelQuestionWeight {
			get {
				return new Label {
					Font = Font.OfSize("Roboto-Thin", 26),
					TextColor = Color.FromHex("fafaf5"),
					Text = "Quantos quilos você\rdeseja perder?"
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
					MaxLength = 4,
					Keyboard = Keyboard.Numeric
				};
			}
		}

		/// <summary>
		/// Gets the label question time.
		/// </summary>
		/// <value>The label question time.</value>
		Label LabelQuestionTime {
			get {
				return new Label {
					Font = Font.OfSize("Roboto-Thin", 26),
					TextColor = Color.FromHex("fafaf5"),
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
					MaxLength = 4,
					Keyboard = Keyboard.Numeric
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