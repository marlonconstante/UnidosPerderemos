using System;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public class MainPage : TabbedPage, IControlPage
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
	}
}