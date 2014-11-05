using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.Contact
{
	public class ContactPage : ContentPage, IControlPage
	{
		public ContactPage()
		{
			SetUp();

			Content = ListView;
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Contatos";
			Icon = ImageSource.FromFile("Contact.png") as FileImageSource;
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			LoadContacts();
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
		} = new ListView {
			ItemTemplate = new DataTemplate(typeof(ContactCell))
		};

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

		/// <summary>
		/// Backgrounds the name of the image.
		/// </summary>
		/// <returns>The image name.</returns>
		public string BackgroundImageName()
		{
			return "Background-4.jpg";
		}
	}
}