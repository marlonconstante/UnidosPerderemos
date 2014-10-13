using System;
using Xamarin.Forms;

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
			DisplayAlert("Configurações", "Abrir tela de configurações", "Cancelar");
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