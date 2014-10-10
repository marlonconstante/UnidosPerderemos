using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public partial class TacticPage : ContentPage
	{
		public TacticPage()
		{
			InitializeComponent();

			BackgroundImage = "BackgroundGoal.png";

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10d,
					Children = {
						new StackLayout {
							Spacing = 10d,
							Padding = new Thickness(16d, 25d),
							Children = {
								LabelQuestionTactics,
								LabelPretension
							}
						},
						SwitchExercise,
						SwitchFeed,
						new StackLayout {
							Padding = new Thickness(16d, 54d),
							Children = {
								ButtonContinue
							}
						}
					}
				}
			};
		}

		/// <summary>
		/// Gets the label question tactics.
		/// </summary>
		/// <value>The label question tactics.</value>
		CompressedLabel LabelQuestionTactics {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-ThinItalic", 40),
					TextColor = Color.FromHex("fcff00"),
					Text = "QUAIS SERÃO\nSUAS TÁTICAS?",
					TranslationY = 37d,
					HeightRequest = 144d
				}; 
			}
		}

		/// <summary>
		/// Gets the label pretension.
		/// </summary>
		/// <value>The label pretension.</value>
		CompressedLabel LabelPretension {
			get {
				return new CompressedLabel {
					Font = Font.OfSize("Roboto-Thin", 22),
					Text = "Para perder peso, eu pretendo:"
				};
			}
		}

		/// <summary>
		/// Gets the switch exercise.
		/// </summary>
		/// <value>The switch exercise.</value>
		SwitchBox SwitchExercise {
			get {
				return new SwitchBox {
					IsToggled = true,
					Font = Font.OfSize("Roboto-Light", 22),
					Text = "Fazer exercícios",
					TranslationY = 10d
				};
			}
		}

		/// <summary>
		/// Gets the switch feed.
		/// </summary>
		/// <value>The switch feed.</value>
		SwitchBox SwitchFeed {
			get {
				return new SwitchBox {
					IsToggled = true,
					Font = Font.OfSize("Roboto-Light", 22),
					Text = "Cuidar da alimentação",
					TranslationY = 10d
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