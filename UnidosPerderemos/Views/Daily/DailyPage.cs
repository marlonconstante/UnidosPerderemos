using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;

namespace UnidosPerderemos.Views.Daily
{
	public class DailyPage : ContentPage, IControlPage
	{
		public DailyPage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 5d,
					Padding = new Thickness(0d, 15d, 0d, 0d),
					Children = {
						PerformanceExercise,
						PerformanceFeed,
						ActivityToday,
						GridButton
					}
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Como foi seu dia?";
			BackgroundColor = Color.FromHex("ef6a2a");

			ButtonCancel.Clicked += OnCancelClicked;
			ButtonUp.Clicked += OnUpClicked;
		}

		/// <summary>
		/// Raises the cancel clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async void OnCancelClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
		}

		/// <summary>
		/// Raises the up clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async void OnUpClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
		}

		/// <summary>
		/// Gets the performance exercise.
		/// </summary>
		/// <value>The performance exercise.</value>
		PerformanceViewBox PerformanceExercise {
			get {
				return new PerformanceViewBox {
					IconImage = ImageSource.FromFile("BenchPresses.png"),
					IconText = "Você fez exercícios?"
				};
			}
		}

		/// <summary>
		/// Gets the performance feed.
		/// </summary>
		/// <value>The performance feed.</value>
		PerformanceViewBox PerformanceFeed {
			get {
				return new PerformanceViewBox {
					IconImage = ImageSource.FromFile("Apple.png"),
					IconText = "Cuidou da alimentação?"
				};
			}
		}

		/// <summary>
		/// Gets the activity today.
		/// </summary>
		/// <value>The activity today.</value>
		ActivityTodayViewBox ActivityToday {
			get {
				return new ActivityTodayViewBox {
					Padding = new Thickness(0d, 30d, 0d, 13d)
				};
			}
		}

		/// <summary>
		/// Gets the grid button.
		/// </summary>
		/// <value>The grid button.</value>
		Grid GridButton {
			get {
				return new Grid {
					Padding = new Thickness(5d),
					ColumnSpacing = 5d,
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					Children = {
						{ ButtonCancel, 0, 0 },
						{ ButtonUp, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the button cancel.
		/// </summary>
		/// <value>The button cancel.</value>
		GhostButton ButtonCancel {
			get;
		} = new GhostButton {
			Text = "CANCELAR",
			Font = Font.OfSize("Roboto-LightItalic", 18),
			HeightRequest = 50d
		};

		/// <summary>
		/// Gets the button up.
		/// </summary>
		/// <value>The button up.</value>
		Button ButtonUp {
			get;
		} = new Button {
			Text = "UP!",
			Font = Font.OfSize("Roboto-BoldItalic", 18),
			TextColor = Color.FromHex("ef6a2a"),
			BackgroundColor = Color.FromHex("fcff00"),
			BorderRadius = 5,
			HeightRequest = 50d
		};

		/// <summary>
		/// Preferreds the status bar style.
		/// </summary>
		/// <returns>The status bar style.</returns>
		public StatusBarStyle PreferredStatusBarStyle()
		{
			return StatusBarStyle.Dark;
		}

		/// <summary>
		/// Determines whether this instance is show navigation bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show navigation bar; otherwise, <c>false</c>.</returns>
		public bool IsShowNavigationBar()
		{
			return true;
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
			return null;
		}
	}
}