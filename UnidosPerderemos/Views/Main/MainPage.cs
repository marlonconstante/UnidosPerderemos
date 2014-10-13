using System;
using Xamarin.Forms;
using UnidosPerderemos.Views.Contact;

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
			Children.Add(new ContactPage());
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