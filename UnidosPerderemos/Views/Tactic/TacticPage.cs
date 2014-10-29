﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UnidosPerderemos.Views.Main;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Views.Login;
using UnidosPerderemos.Models;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.Tactic
{
	public class TacticPage : ContentPage, IControlPage
	{
		public TacticPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10d,
					Children = {
						new StackLayout {
							Spacing = 10d,
							Padding = new Thickness(16d, 25d),
							Children = {
								QuestionTacticsBox,
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
		async void OnContinueClicked(object sender, EventArgs args)
		{
			UserProfile.IsTacticExercise = SwitchExercise.IsToggled;
			UserProfile.IsTacticFeed = SwitchFeed.IsToggled;

			if (await DependencyService.Get<IUserProfileService>().Save(UserProfile))
			{
				await Navigation.PushModalAsync(MainFlow);

				await ActivationFlow.PopToRootAsync();
				if (!IsHomePage)
				{
					await ActivationFlow.PopAsync();
					await ActivationFlow.PushAsync(new HomePage());
				}
			}
			else
			{
				DisplayAlert("Ops...", "Ocorreu uma falha na conexão com o servidor.", "Entendi");
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is home page.
		/// </summary>
		/// <value><c>true</c> if this instance is home page; otherwise, <c>false</c>.</value>
		bool IsHomePage {
			get {
				return ActivationFlow.CurrentPage is HomePage;
			}
		}

		/// <summary>
		/// Gets the question tactics box.
		/// </summary>
		/// <value>The question tactics box.</value>
		StackLayout QuestionTacticsBox {
			get {
				return new StackLayout {
					Padding = new Thickness(0d, 37d, 0d, 20d),
					Children = {
						new CompressedLabel {
							Font = Font.OfSize("Roboto-ThinItalic", 40),
							TextColor = Color.FromHex("fcff00"),
							Text = "QUAIS SERÃO SUAS TÁTICAS?"
						}
					}
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
			get;
		} = new SwitchBox {
			IsToggled = true,
			Font = Font.OfSize("Roboto-Light", 22),
			Text = "Fazer exercícios",
			TranslationY = 10d
		};

		/// <summary>
		/// Gets the switch feed.
		/// </summary>
		/// <value>The switch feed.</value>
		SwitchBox SwitchFeed {
			get;
		} = new SwitchBox {
			IsToggled = true,
			Font = Font.OfSize("Roboto-Light", 22),
			Text = "Cuidar da alimentação",
			TranslationY = 10d
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
				return App.CurrentUserProfile;
			}
		}

		/// <summary>
		/// Gets the activation flow.
		/// </summary>
		/// <value>The activation flow.</value>
		FlowPage ActivationFlow {
			get {
				return App.ActivationFlow;
			}
		}

		/// <summary>
		/// Gets the main flow.
		/// </summary>
		/// <value>The main flow.</value>
		MainFlowPage MainFlow {
			get {
				return App.MainFlow;
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
	}
}