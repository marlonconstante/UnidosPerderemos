using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using UnidosPerderemos.Views.Profile;

namespace UnidosPerderemos.Views.Friend
{
	public class FriendPage : ContentPage, IControlPage, ISecurePage
	{
		public FriendPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Amigos";
			Icon = ImageSource.FromFile("Contact.png") as FileImageSource;

			ListView.ItemTapped += async (object sender, ItemTappedEventArgs args) => {
				var friend = (sender as ListView).SelectedItem as PersonFacebook;

				var profilePage = new ProfilePage(friend.Name);
				await Navigation.PushModalAsync(new FlowPage(profilePage));

				var friendProfile = await DependencyService.Get<IProfileService>().LoadFriend(friend.Id);
				profilePage.OnUserProfileLoaded(friendProfile);
			};

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
					ListView
				}
			};
		}

		/// <summary>
		/// Raises the user profile loaded event.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public void OnUserProfileLoaded(UserProfile userProfile)
		{
			SetContentPage();

			LoadFriends();
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!IsFacebookUser)
			{
				DisplayAlert("Ops...", "Para visualizar amigos, conecte-se com o facebook.", "Entendi");
			}
		}

		/// <summary>
		/// Loads the friends.
		/// </summary>
		async void LoadFriends()
		{
			if (IsFacebookUser)
			{
				ListView.ItemsSource = await DependencyService.Get<IFacebookService>().FindAllFriends();
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
		/// Gets the list view.
		/// </summary>
		/// <value>The list view.</value>
		ListView ListView {
			get;
		} = new ListView {
			ItemTemplate = new DataTemplate(typeof(FriendCell)),
			BackgroundColor = Color.Transparent,
			RowHeight = 52
		};

		/// <summary>
		/// Gets a value indicating whether this instance is facebook user.
		/// </summary>
		/// <value><c>true</c> if this instance is facebook user; otherwise, <c>false</c>.</value>
		bool IsFacebookUser {
			get {
				return App.Instance.CurrentUser.IsFacebookUser;
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