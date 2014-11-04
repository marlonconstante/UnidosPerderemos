using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Views.Config
{
	public class ConfigPageNavigation : NavigationPage
	{
		public ConfigPageNavigation()
		{
			PushAsync(new ConfigPage());
		}
	}
}

