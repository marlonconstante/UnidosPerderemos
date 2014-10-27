using System;
using UnidosPerderemos.Core.Controls;
using Xamarin.Forms;

namespace UnidosPerderemos.Views.Login
{
	public class FacebookButton : GhostButton
	{
		public FacebookButton()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Image = ImageSource.FromFile("Facebook.png") as FileImageSource;

			BorderColor = Color.FromHex("5efffd");

			TextColor = Color.FromHex("5efffd");
			Font = Font.OfSize("Roboto-LightItalic", 19);
		}
	}
}