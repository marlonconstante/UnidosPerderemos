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
			if (!IsUserProfileLoaded)
			{
				await App.Instance.LoadUserProfile();

				foreach (var page in Children.Where((page) => page is ISecurePage))
				{
					((ISecurePage) page).OnUserProfileLoaded(UserProfile);
				}

				IsUserProfileLoaded = true;
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
		/// Updates the history.
		/// </summary>
		public void UpdateHistory()
		{
			HistoryPage.UpdateHistory();
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is user profile loaded.
		/// </summary>
		/// <value><c>true</c> if this instance is user profile loaded; otherwise, <c>false</c>.</value>
		bool IsUserProfileLoaded {
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

		/// <summary>
		/// Gets the history page.
		/// </summary>
		/// <value>The history page.</value>
		HistoryPage HistoryPage {
			get {
				return Children[0] as HistoryPage;
			}
		}
	}
}