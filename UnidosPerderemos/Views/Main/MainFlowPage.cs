using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Services;
using UnidosPerderemos.Views.Config;

namespace UnidosPerderemos.Views.Main
{
	public class MainFlowPage : FlowPage
	{
		public MainFlowPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			ConfigItem.Activated += OnConfigActivated;

			ToolbarItems.Add(ConfigItem);
		}

		/// <summary>
		/// Raises the config activated event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnConfigActivated(object sender, EventArgs args) {
			Navigation.PushAsync(new ConfigPage());
		}

		/// <summary>
		/// Logout this instance.
		/// </summary>
		void Logout()
		{
			DependencyService.Get<IUserService>().Logout();
			Navigation.PopModalAsync();
		}

		/// <summary>
		/// Gets the config item.
		/// </summary>
		/// <value>The config item.</value>
		ToolbarItem ConfigItem {
			get;
		} = new ToolbarItem {
			Icon = ImageSource.FromFile("Gear.png") as FileImageSource
		};
	}
}