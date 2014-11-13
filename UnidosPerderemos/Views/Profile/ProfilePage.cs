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
		public ProfilePage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Perfil";
			Icon = ImageSource.FromFile("Profile.png") as FileImageSource;

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
			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 5d,
					Children = {
						ProfileViewBox,
						UpButton,
						TransparentSeparator,
						GridGraphics
					}
				}
			};
		}

		/// <summary>
		/// Updates the status.
		/// </summary>
		void UpdateStatus()
		{
			if (UserProfileLoaded)
			{
				UpButton.IsDone = UserProfile.DateLastDaily == DateTime.Now.Date;

				//TODO: Dados fictícios por enquanto...
				UpButton.IsStar = !UpButton.IsStar;

				ProfileViewBox.Progress += 12;
				DedicationGraphics.Progress += 8;
				GoalGraphics.Progress += 4;
			}
		}

		/// <summary>
		/// Raises the user profile loaded event.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public void OnUserProfileLoaded(UserProfile userProfile)
		{
			SetContentPage();
			UpdateStatus();
			ProfileViewBox.LoadPhoto();
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
		/// Gets the profile view box.
		/// </summary>
		/// <value>The profile view box.</value>
		ProfileViewBox ProfileViewBox {
			get;
		} = new ProfileViewBox();

		/// <summary>
		/// Gets up button.
		/// </summary>
		/// <value>Up button.</value>
		UpButton UpButton {
			get;
			set;
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
		/// Gets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get {
				return App.Instance.CurrentUserProfile;
			}
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