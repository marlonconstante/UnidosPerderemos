using System;
using Xamarin.Forms;
using UnidosPerderemos.Views.History;
using UnidosPerderemos.Views.Profile;
using UnidosPerderemos.Views.Friend;

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
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			App.Instance.LoadUserProfile();
		}

		/// <summary>
		/// Raises the current page changed event.
		/// </summary>
		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			Title = CurrentPage.Title;
		}
	}
}