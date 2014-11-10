using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnidosPerderemos.Models;
using Xamarin.Contacts;
using System.Linq;

namespace UnidosPerderemos.iOS.Services
{
	public class HistoryService
	{
		public HistoryService()
		{
		}

		/// <summary>
		/// Finds all contacts.
		/// </summary>
		/// <returns>The all contacts.</returns>
//		public async Task<IList<PersonContact>> FindAllContacts()
//		{
//			var contacts = new List<PersonContact>();
//
//			await RunIfPermissionIsGranted(() =>
//			{
//				foreach (var contact in AddressBook)
//				{
//					contacts.Add(new PersonContact
//					{
//						Id = contact.Id,
//						Name = contact.DisplayName
//					});
//				}
//			});
//
//			return contacts.OrderBy(c => c.Name).ToList();
//		}
//
//		/// <summary>
//		/// Runs if permission is granted.
//		/// </summary>
//		/// <returns>The if permission is granted.</returns>
//		/// <param name="action">Action.</param>
//		async Task RunIfPermissionIsGranted(Action action)
//		{
//			await AddressBook.RequestPermission().ContinueWith(t => {
//				if (t.Result)
//				{
//					action();
//				}
//			}, TaskScheduler.FromCurrentSynchronizationContext());
//		}
	}
}

