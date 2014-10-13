using System;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public class HistoryPage : ContentPage
	{
		public HistoryPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Histórico";
			Icon = ImageSource.FromFile("History.png") as FileImageSource;
			BackgroundImage = "BackgroundGoal.png";
		}
	}
}