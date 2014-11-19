using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Models;
using UnidosPerderemos.Services;
using System.Collections.Generic;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Views.Daily;
using UnidosPerderemos.Views.Weekly;

namespace UnidosPerderemos.Views.History
{
	public class HistoryPage : ContentPage, IControlPage, ISecurePage
	{
		public HistoryPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Histórico";
			Icon = ImageSource.FromFile("History.png") as FileImageSource;

			InputProgressType.Items = ProgressTypeInfo.GetItems();
			InputProgressType.SelectedItem = ProgressType.Daily;
			InputProgressType.AfterSelectedItem += (object sender, EventArgs args) => {
				UpdateHistory();
			};

			SetContentPage();
		}

		/// <summary>
		/// Sets the content page.
		/// </summary>
		void SetContentPage()
		{
			Content = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = new GridLength(1d, GridUnitType.Star)
					}
				},
				RowDefinitions = {
					new RowDefinition {
						Height = new GridLength(1d, GridUnitType.Star)
					}
				},
				Children = {
					BackgroundGradient,
					ContentLayout,
					ActivityIndicator
				}
			};
		}

		/// <summary>
		/// Raises the user profile loaded event.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public void OnUserProfileLoaded(UserProfile userProfile)
		{
			UpdateHistory();
		}

		/// <summary>
		/// Updates the history.
		/// </summary>
		public void UpdateHistory()
		{
			ReloadItems(App.Instance.CurrentUser, (ProgressType) InputProgressType.SelectedItem);
		}

		/// <summary>
		/// Reloads the items.
		/// </summary>
		/// <param name="user">User.</param>
		/// <param name="type">Type.</param>
		async void ReloadItems(User user, ProgressType type)
		{
			if (UserProfileLoaded)
			{
				ActivityIndicator.IsVisible = true;

				DailyListView.IsVisible = type == ProgressType.Daily;
				WeeklyProgressView.IsVisible = type == ProgressType.Weekly;
				WeeklyProgressView.Opacity = WeeklyProgressView.IsVisible ? 1d : 0d;

				if (DailyListView.IsVisible)
				{
					DailyListView.ItemsSource = await DependencyService.Get<IProgressService>().Find(user);
				}
				else
				{
				}

				ActivityIndicator.IsVisible = false;
			}
		}

		/// <summary>
		/// Gets the background gradient.
		/// </summary>
		/// <value>The background gradient.</value>
		Image BackgroundGradient {
			get {
				return new Image {
					Source = ImageSource.FromFile("BackgroundGradient.png"),
					Aspect = Aspect.Fill
				};
			}
		}

		/// <summary>
		/// Gets the content layout.
		/// </summary>
		/// <value>The content layout.</value>
		StackLayout ContentLayout {
			get {
				return new StackLayout {
					Spacing = 0d,
					Children = {
						ProgressTypeBox,
						DailyListView,
						WeeklyProgressView
					}
				};
			}
		}

		/// <summary>
		/// Gets the activity indicator.
		/// </summary>
		/// <value>The activity indicator.</value>
		ActivityIndicator ActivityIndicator {
			get;
		} = new ActivityIndicator {
			Color = Color.White,
			IsRunning = true
		};

		/// <summary>
		/// Gets the progress type box.
		/// </summary>
		/// <value>The progress type box.</value>
		StackLayout ProgressTypeBox {
			get {
				return new StackLayout {
					Padding = new Thickness(10d, 10d, 10d, 0d),
					Children = {
						InputProgressType
					}
				};
			}
		}

		/// <summary>
		/// Gets the daily list view.
		/// </summary>
		/// <value>The daily list view.</value>
		ListView DailyListView {
			get;
		} = new ListView {
			ItemTemplate = new DataTemplate(typeof(DailyCell)),
			BackgroundColor = Color.Transparent,
			HasUnevenRows = true
		};

		/// <summary>
		/// Gets the weekly progress view.
		/// </summary>
		/// <value>The weekly progress view.</value>
		WeeklyProgressView WeeklyProgressView {
			get;
		} = new WeeklyProgressView {
			IsVisible = false,
			Opacity = 0d
		};

		/// <summary>
		/// Gets the type of the input progress.
		/// </summary>
		/// <value>The type of the input progress.</value>
		OptionButton InputProgressType {
			get;
		} = new OptionButton {
			TintColor = Color.FromHex("f26522")
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
		/// Gets a value indicating whether this <see cref="UnidosPerderemos.Views.History.HistoryPage"/> user profile loaded.
		/// </summary>
		/// <value><c>true</c> if user profile loaded; otherwise, <c>false</c>.</value>
		bool UserProfileLoaded {
			get {
				return UserProfile != null;
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
			return "Background-4.jpg";
		}
	}
}