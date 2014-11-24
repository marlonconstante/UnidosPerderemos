using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using System.Diagnostics;
using UnidosPerderemos.Models;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfilePage : ContentPage, IControlPage, ISecurePage
	{
		/// <summary>
		/// The default title.
		/// </summary>
		const string DefaultTitle = "Perfil";

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Views.Profile.ProfilePage"/> class.
		/// </summary>
		/// <param name="title">Title.</param>
		public ProfilePage(string title = DefaultTitle)
		{
			SetUp(title);
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		/// <param name="title">Title.</param>
		void SetUp(string title)
		{
			Title = title;
			Icon = ImageSource.FromFile("Profile.png") as FileImageSource;

			if (!DefaultTitle.Equals(title))
			{
				ToolbarItems.Add(new LeftToolbarItem {
					Name = "Cancelar",
					Command = new Command(() => Navigation.PopModalAsync())
				});
			}

			Content = new ActivityIndicator {
				Color = Color.White,
				IsRunning = true
			};
		}

		/// <summary>
		/// Sets the content page.
		/// </summary>
		void SetContentPage()
		{
			ContentView.Children.Add(ProfileViewBox);
			if (IsCurrentUserProfile)
			{
				ContentView.Children.Add(UpButton);
				ContentView.Children.Add(TransparentSeparator);
			}
			ContentView.Children.Add(GridGraphics);

			Content = new ScrollView {
				Content = ContentView
			};
		}

		/// <summary>
		/// Updates the status.
		/// </summary>
		void UpdateStatus()
		{
			if (UserProfileLoaded)
			{
				ProfileViewBox.UpdateInfo();

				if (IsCurrentUserProfile)
				{
					UpButton.IsDone = UserProfile.IsDailyPerformed;
					UpButton.IsStar = UserProfile.IsPrizewinner;
				}

				ProfileViewBox.Progress = UserProfile.DailyProgress;
				DedicationGraphics.Progress = UserProfile.DedicationProgress;
				GoalGraphics.Progress = UserProfile.GoalProgress;
			}
		}

		/// <summary>
		/// Raises the user profile loaded event.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public void OnUserProfileLoaded(UserProfile userProfile)
		{
			UserProfile = userProfile;
			ProfileViewBox = new ProfileViewBox(userProfile);
			SetContentPage();
			UpdateStatus();
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			UpdateStatus();
		}

		/// <summary>
		/// Gets the content view.
		/// </summary>
		/// <value>The content view.</value>
		StackLayout ContentView {
			get;
		} = new StackLayout {
			Spacing = 5d
		};

		/// <summary>
		/// Gets or sets the profile view box.
		/// </summary>
		/// <value>The profile view box.</value>
		ProfileViewBox ProfileViewBox {
			get;
			set;
		}

		/// <summary>
		/// Gets up button.
		/// </summary>
		/// <value>Up button.</value>
		UpButton UpButton {
			get;
		} = new UpButton();

		/// <summary>
		/// Gets the transparent separator.
		/// </summary>
		/// <value>The transparent separator.</value>
		BoxView TransparentSeparator {
			get {
				return new BoxView {
					BackgroundColor = Color.White.MultiplyAlpha(0.6d),
					HeightRequest = 1d
				};
			}
		}

		/// <summary>
		/// Gets the grid graphics.
		/// </summary>
		/// <value>The grid graphics.</value>
		Grid GridGraphics {
			get {
				return new Grid {
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					Children = {
						{ DedicationGraphics, 0, 0 },
						{ GoalGraphics, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the dedication graphics.
		/// </summary>
		/// <value>The dedication graphics.</value>
		ProfileViewGraphics DedicationGraphics {
			get;
		} = new ProfileViewGraphics {
			Title = "Dedicação",
			Type = RadialProgressType.Dedication
		};

		/// <summary>
		/// Gets the goal graphics.
		/// </summary>
		/// <value>The goal graphics.</value>
		ProfileViewGraphics GoalGraphics {
			get;
		} = new ProfileViewGraphics {
			Title = "Meta",
			Type = RadialProgressType.Goal
		};

		/// <summary>
		/// Gets or sets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="UnidosPerderemos.Views.Profile.ProfilePage"/> user profile loaded.
		/// </summary>
		/// <value><c>true</c> if user profile loaded; otherwise, <c>false</c>.</value>
		bool UserProfileLoaded {
			get {
				return UserProfile != null;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is current user profile.
		/// </summary>
		/// <value><c>true</c> if this instance is current user profile; otherwise, <c>false</c>.</value>
		bool IsCurrentUserProfile {
			get {
				return UserProfile == App.Instance.CurrentUserProfile;
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