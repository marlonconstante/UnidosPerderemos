﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public partial class ContactPage : ContentPage, IControlPage
	{
		public ContactPage()
		{
			InitializeComponent();

			ConfigListView();
			LoadContacts();

			Content = ListView;
		}

		/// <summary>
		/// Configs the list view.
		/// </summary>
		void ConfigListView()
		{
			ListView = new ListView {
				ItemTemplate = new DataTemplate(typeof(ContactCell))
			};
		}

		/// <summary>
		/// Loads the contacts.
		/// </summary>
		async void LoadContacts()
		{
			ListView.ItemsSource = await DependencyService.Get<IAddressBookService>().FindAllContacts();
		}

		/// <summary>
		/// Gets or sets the list view.
		/// </summary>
		/// <value>The list view.</value>
		ListView ListView {
			get;
			set;
		}

		/// <summary>
		/// Preferreds the status bar style.
		/// </summary>
		/// <returns>The status bar style.</returns>
		public StatusBarStyle PreferredStatusBarStyle()
		{
			return StatusBarStyle.Dark;
		}

		/// <summary>
		/// Determines whether this instance is show navigation bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show navigation bar; otherwise, <c>false</c>.</returns>
		public bool IsShowNavigationBar()
		{
			return true;
		}

		/// <summary>
		/// Determines whether this instance is show status bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show status bar; otherwise, <c>false</c>.</returns>
		public bool IsShowStatusBar()
		{
			return true;
		}
	}
}