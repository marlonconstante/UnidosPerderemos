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
		}

		/// <summary>
		/// Builds the list view.
		/// </summary>
		/// <returns>The list view.</returns>
		ListView BuildListView()
		{
			var listView = new ListView {
				ItemTemplate = new DataTemplate(typeof(EnterpriseSelectionItemCell)),
				ItemsSource = DependencyService.Get<IAddressBook>().FindAllContacts()
			};
			return listView;
		}
	}
}