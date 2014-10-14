using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfilePage : ContentPage, IControlPage
	{
		public ProfilePage()
		{
			SetUp();

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10d,
					Children = {
						BackgroundProfileBox,
						ButtonUp
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
			BackgroundImage = "BackgroundProfile.png";
		}

		/// <summary>
		/// Gets the background profile box.
		/// </summary>
		/// <value>The background profile box.</value>
		public Image BackgroundProfileBox {
			get {
				return new Image {
					Source = ImageSource.FromFile("BackgroundProfileBox.png"),
					Aspect = Aspect.AspectFill
				};
			}
		}

		/// <summary>
		/// Gets the button up.
		/// </summary>
		/// <value>The button up.</value>
		public Image ButtonUp {
			get {
				return new Image {
					Source = ImageSource.FromFile("ButtonUp.png"),
					WidthRequest = 239d,
					HeightRequest = 208d
				};
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
	}
}