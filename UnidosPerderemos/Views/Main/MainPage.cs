using System;
using Xamarin.Forms;
using UnidosPerderemos.Views.History;
using UnidosPerderemos.Views.Profile;
using UnidosPerderemos.Views.Friend;
using UnidosPerderemos.Core.Pages;
using System.Linq;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.Main
{
	public class MainPage : TabbedPage
	{
		public MainPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Children.Add(new HistoryPage());
			Children.Add(new ProfilePage());
			Children.Add(new FriendPage());

			CurrentPage = Children[1];
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			LoadUserProfile();
		}

		/// <summary>
		/// Loads the user profile.
		/// </summary>
		async void LoadUserProfile()
		{
			if (!UserProfileLoaded)
			{
				await App.Instance.LoadUserProfile();

				foreach (var page in Children.Where((page) => page is ISecurePage))
				{
					((ISecurePage) page).OnUserProfileLoaded(UserProfile);
				}

				UserProfileLoaded = true;
			}
		}

		/// <summary>
		/// Raises the current page changed event.
		/// </summary>
		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			Title = CurrentPage.Title;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnidosPerderemos.Views.Main.MainPage"/> user profile loaded.
		/// </summary>
		/// <value><c>true</c> if user profile loaded; otherwise, <c>false</c>.</value>
		bool UserProfileLoaded {
			get;
			set;
		} = false;

		/// <summary>
		/// Gets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get {
				return App.Instance.CurrentUserProfile;
			}
		}
	}
}