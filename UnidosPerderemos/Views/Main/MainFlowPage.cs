﻿using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Services;
using UnidosPerderemos.Views.Config;

namespace UnidosPerderemos.Views.Main
{
	public class MainFlowPage : FlowPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Views.Main.MainFlowPage"/> class.
		/// </summary>
		/// <param name="startPage">Start page.</param>
		public MainFlowPage(Page startPage) : base(startPage)
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
		void OnConfigActivated(object sender, EventArgs args)
		{
			Navigation.PushAsync(new ConfigPage());
		}

		/// <summary>
		/// Gets the config item.
		/// </summary>
		/// <value>The config item.</value>
		ToolbarItem ConfigItem
		{
			get;
		} = new ToolbarItem {
			Icon = ImageSource.FromFile("Gear.png") as FileImageSource
		};
	}
}