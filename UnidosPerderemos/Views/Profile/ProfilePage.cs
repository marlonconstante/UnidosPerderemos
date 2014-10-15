using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfilePage : ContentPage, IControlPage
	{
		public ProfilePage()
		{
			SetUp();

			Content = new StackLayout
			{
				Spacing = 10d,
				Children =
				{
					new StackLayout
					{
						Spacing = 10d,
						Padding = new Thickness(16d, 25d),
						Children =
						{
							DedicationBar
						}
					}
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Perfil";
			Icon = ImageSource.FromFile("Profile.png") as FileImageSource;
			BackgroundImage = "BackgroundGoal.png";
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

		public RadialProgressBar DedicationBar
		{
			get
			{
				return new RadialProgressBar();
			}
		}
	}
}