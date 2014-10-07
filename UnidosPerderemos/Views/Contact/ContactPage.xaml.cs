using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public partial class ContactPage : ContentPage
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
	}
}