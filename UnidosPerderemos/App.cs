using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Views.Main;
using UnidosPerderemos.Views.Login;

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
			ActivationFlow.PushAsync(new HomePage());
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