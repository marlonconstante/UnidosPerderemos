using System;
using Xamarin.Forms;
using UnidosPerderemos.Views.Main;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Views.Goal;

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
		public static MainFlowPage MainFlow {
			get;
		} = new MainFlowPage();
	}
}