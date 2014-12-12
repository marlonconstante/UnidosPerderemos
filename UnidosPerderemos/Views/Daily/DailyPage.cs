using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using UnidosPerderemos.Views.Weekly;
using System.Threading.Tasks;

namespace UnidosPerderemos.Views.Daily
{
	public class DailyPage : ContentPage, IControlPage
	{
		public DailyPage()
		{
			SetUp();
			LoadDaily();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Como foi seu dia?";
			BackgroundColor = Color.FromHex("ef6a2a");

			ButtonCancel.Clicked += OnCancelClicked;
			ButtonUp.Clicked += (object sender, EventArgs args) => {
				if (UserProfile.IsWeeklyPerformed)
				{
					OnUpClicked(sender, args);
				}
				else
				{
					WeeklyModal.Show();
				}
			};
			WeeklyModal.ConfirmClicked += OnUpClicked;

			ContentView = new StackLayout {
				Spacing = 5d,
				Padding = new Thickness(0d, 15d, 0d, 0d),
				Children = {
					ActivityIndicator,
					GridButton
				}
			};

			Content = new ScrollView {
				Content = new GridView {
					Children = {
						ContentView,
						WeeklyModal
					}
				}
			};
		}

		/// <summary>
		/// Updates the content view.
		/// </summary>
		void UpdateContentView()
		{
			ContentView.Children[0] = new StackLayout {
				Spacing = 5d,
				Padding = new Thickness(0d),
				Children = {
					PerformanceExercise,
					PerformanceFeed,
					ActivityToday
				}
			};

			ButtonUp.IsEnabled = true;
			ButtonUp.Opacity = 1;
		}

		/// <summary>
		/// Loads the daily.
		/// </summary>
		async void LoadDaily()
		{
			UserProgress = await DependencyService.Get<IProgressService>().Load();

			PerformanceExercise.Performance = UserProgress.PerformanceExercise;
			PerformanceFeed.Performance = UserProgress.PerformanceFeed;
			ActivityToday.Text = UserProgress.Comments;
			ActivityToday.Photo = UserProgress.Photo;
			ActivityToday.UpdatePhoto();

			UpdateContentView();
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
			var button = sender as Button;
			try {
				button.IsEnabled = false;
				await SaveUserProgress();
			} finally {
				button.IsEnabled = true;
			}
		}

		/// <summary>
		/// Saves the user progress.
		/// </summary>
		/// <returns>The user progress.</returns>
		async Task SaveUserProgress()
		{
			if (UserProgress.ObjectId == null)
			{
				UserProgress.Type = UserProfile.IsWeeklyPerformed ? ProgressType.Daily : ProgressType.Weekly;
			}

			UserProgress.PerformanceExercise = PerformanceExercise.Performance;
			UserProgress.PerformanceFeed = PerformanceFeed.Performance;
			UserProgress.Comments = ActivityToday.Text;
			UserProgress.Weight = UserProfile.Weight;

			if (await DependencyService.Get<IProgressService>().Save(UserProgress))
			{
				var withoutPrize = !UserProfile.IsPrizewinner;

				UserProfile.DateLastDaily = UserProgress.Date;
				if (UserProgress.Type == ProgressType.Weekly)
				{
					UserProfile.DateLastWeekly = UserProgress.Date;
				}
				UserProfile.WeeklyDedication = UserProgress.WeeklyDedication;

				if (withoutPrize && UserProfile.IsPrizewinner)
				{
					await DisplayAlert("Parabéns!", "Você foi premiado com uma estrela por sua dedicação.", "Entendi");
				}
				else
				{
					await DisplayAlert("Pronto!", "Progresso atualizado com sucesso.", "Entendi");
				}

				await Navigation.PopModalAsync();
			}
			else
			{
				await DisplayAlert("Ops...", "Ocorreu uma falha na conexão com o servidor.", "Entendi");
			}
		}

		/// <summary>
		/// Gets or sets the content view.
		/// </summary>
		/// <value>The content view.</value>
		StackLayout ContentView {
			get;
			set;
		}

		/// <summary>
		/// Gets the weekly modal.
		/// </summary>
		/// <value>The weekly modal.</value>
		WeeklyModalView WeeklyModal {
			get;
		} = new WeeklyModalView();

		/// <summary>
		/// Gets the activity indicator.
		/// </summary>
		/// <value>The activity indicator.</value>
		ActivityIndicator ActivityIndicator {
			get;
		} = new ActivityIndicator {
			VerticalOptions = LayoutOptions.CenterAndExpand,
			Color = Color.White,
			IsRunning = true
		};

		/// <summary>
		/// Gets the performance exercise.
		/// </summary>
		/// <value>The performance exercise.</value>
		PerformanceViewBox PerformanceExercise {
			get;
		} = new PerformanceViewBox {
			IconImage = ImageSource.FromFile("BenchPresses.png"),
			IconText = "Você fez exercícios?"
		};

		/// <summary>
		/// Gets the performance feed.
		/// </summary>
		/// <value>The performance feed.</value>
		PerformanceViewBox PerformanceFeed {
			get;
		} = new PerformanceViewBox {
			IconImage = ImageSource.FromFile("Apple.png"),
			IconText = "Cuidou da alimentação?"
		};

		/// <summary>
		/// Gets the activity today.
		/// </summary>
		/// <value>The activity today.</value>
		ActivityTodayViewBox ActivityToday {
			get;
		} = new ActivityTodayViewBox {
			Padding = new Thickness(0d, 30d, 0d, 13d)
		};

		/// <summary>
		/// Gets the grid button.
		/// </summary>
		/// <value>The grid button.</value>
		Grid GridButton {
			get {
				return new Grid {
					VerticalOptions = LayoutOptions.End,
					Padding = new Thickness(5d, 5d, 5d, 23d),
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
			Opacity = 0.5,
			BorderRadius = 5,
			HeightRequest = 50d,
			IsEnabled = false
		};

		/// <summary>
		/// Gets or sets the user progress.
		/// </summary>
		/// <value>The user progress.</value>
		public UserProgress UserProgress {
			get;
			set;
		}

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