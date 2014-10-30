using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Views.Main;
using UnidosPerderemos.Views.Login;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using UnidosPerderemos.Views.About;

namespace UnidosPerderemos
{
	public class App : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.App"/> class.
		/// </summary>
		public App()
		{	
			LoadUserProfile();
			ReloadMainPage();
		}

		/// <summary>
		/// Loads the user profile.
		/// </summary>
		async void LoadUserProfile()
		{
			CurrentUserProfile = await DependencyService.Get<IUserProfileService>().Load();
		}

		/// <summary>
		/// Reloads the main page.
		/// </summary>
		public void ReloadMainPage()
		{
			MainPage = IsLoggedUser ? MainFlow : ActivationFlow;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is logged user.
		/// </summary>
		/// <value><c>true</c> if this instance is logged user; otherwise, <c>false</c>.</value>
		public bool IsLoggedUser {
			get {
				return CurrentUser != null;
			}
		}

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		public User CurrentUser {
			get {
				return DependencyService.Get<IUserService>().CurrentUser;
			}
		}

		/// <summary>
		/// Gets or sets the current user profile.
		/// </summary>
		/// <value>The current user profile.</value>
		public UserProfile CurrentUserProfile {
			get;
			set;
		}

		/// <summary>
		/// Gets the main flow.
		/// </summary>
		/// <value>The main flow.</value>
		MainFlowPage MainFlow {
			get {
				return new MainFlowPage(new MainPage());
			}
		}

		/// <summary>
		/// Gets the activation flow.
		/// </summary>
		/// <value>The activation flow.</value>
		FlowPage ActivationFlow {
			get {
				return new FlowPage(new HomePage());
			}
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static App Instance {
			get {
				return App.Current as App;
			}
		}
	}
}