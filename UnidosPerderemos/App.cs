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
			return new TacticPage();
		}
	}
}