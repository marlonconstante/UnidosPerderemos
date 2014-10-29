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
	public class App
	{
		/// <summary>
		/// Gets the main page.
		/// </summary>
		/// <returns>The main page.</returns>
		public static Page GetMainPage()
		{	
			MainFlow.PushAsync(new MainPage());
			LoadUserProfile();
			if (IsLoggedUser)
			{
				ActivationFlow.PushAsync(new AboutPage());
			}
			else
			{
				ActivationFlow.PushAsync(new HomePage());
			}
			return ActivationFlow;
		}

		/// <summary>
		/// Loads the user profile.
		/// </summary>
		static async void LoadUserProfile() {
			CurrentUserProfile = await DependencyService.Get<IUserProfileService>().Load();
		}

		/// <summary>
		/// Gets the activation flow.
		/// </summary>
		/// <value>The activation flow.</value>
		public static FlowPage ActivationFlow {
			get;
		} = new FlowPage();

		/// <summary>
		/// Gets the main flow.
		/// </summary>
		/// <value>The main flow.</value>
		public static MainFlowPage MainFlow {
			get;
		} = new MainFlowPage();

		/// <summary>
		/// Gets a value indicating is logged user.
		/// </summary>
		/// <value><c>true</c> if is logged user; otherwise, <c>false</c>.</value>
		public static bool IsLoggedUser {
			get {
				return CurrentUser != null;
			}
		}

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		public static User CurrentUser {
			get {
				return DependencyService.Get<IUserService>().CurrentUser;
			}
		}

		/// <summary>
		/// Gets or sets the current user profile.
		/// </summary>
		/// <value>The current user profile.</value>
		public static UserProfile CurrentUserProfile {
			get;
			set;
		}
	}
}