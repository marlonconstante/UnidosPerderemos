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
			ActivationFlow.PushAsync(new GoalPage());
			return ActivationFlow;
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
		public static FlowPage MainFlow {
			get;
		} = new FlowPage();
	}
}