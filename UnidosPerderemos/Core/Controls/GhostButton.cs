using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class GhostButton : ImageButton
	{
		public GhostButton()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			BorderWidth = 2d;
			BorderRadius = 5;
			BorderColor = Color.FromHex("fcff00");

			TextColor = Color.FromHex("fcff00");
			Font = Font.OfSize("Roboto-LightItalic", 24);
		}
	}
}