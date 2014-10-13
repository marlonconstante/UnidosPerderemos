using System;
using Xamarin.Forms;

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
			FlowPage.PushAsync(new GoalPage());
			return FlowPage;
		}

		/// <summary>
		/// Gets the flow page.
		/// </summary>
		/// <value>The flow page.</value>
		public static FlowPage FlowPage {
			get;
		} = new FlowPage();
	}
}