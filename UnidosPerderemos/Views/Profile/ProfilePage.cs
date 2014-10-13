using System;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public class ProfilePage : ContentPage
	{
		public ProfilePage()
		{
			SetUp();
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
	}
}