using System;
using System.Collections.Generic;
using Xamarin.Contacts;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using UnidosPerderemos.Models;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.AddressBookService))]
namespace UnidosPerderemos.iOS
{
	public class AddressBookService : IAddressBookService
	{
		public AddressBookService()
		{
			AddressBook = new AddressBook();
		}

		/// <summary>
		/// Gets the phones.
		/// </summary>
		/// <returns>The phones.</returns>
		/// <param name="contact">Contact.</param>
		List<string> GetPhones(Contact contact)
		{
			var phones = new List<string>();

			foreach (var phone in contact.Phones)
			{
				phones.Add(phone.Number);
			}

			return phones;
		}

		/// <summary>
		/// Gets the emails.
		/// </summary>
		/// <returns>The emails.</returns>
		/// <param name="contact">Contact.</param>
		List<string> GetEmails(Contact contact)
		{
			var emails = new List<string>();

			foreach (var email in contact.Emails)
			{
				emails.Add(email.Address);
			}

			return emails;
		}

		/// <summary>
		/// Finds all contacts.
		/// </summary>
		/// <returns>The all contacts.</returns>
		public async Task<IList<PersonContact>> FindAllContacts()
		{
			var contacts = new List<PersonContact>();

			await RunIfPermissionIsGranted(() => {
				foreach (var contact in AddressBook)
				{
					contacts.Add(new PersonContact {
						Id = contact.Id,
						Name = contact.DisplayName,
						Phones = GetPhones(contact),
						Emails = GetEmails(contact)
					});
				}
			});

			return contacts.OrderBy(c => c.Name).ToList();
		}

		/// <summary>
		/// Gets the thumbnail.
		/// </summary>
		/// <returns>The thumbnail.</returns>
		/// <param name="id">Identifier.</param>
		public async Task<Stream> GetThumbnail(string id)
		{
			var stream = Stream.Null;

			await RunIfPermissionIsGranted(() => {
				using (var image = AddressBook.Load(id).GetThumbnail())
				{
					if (image != null)
					{
						stream = image.AsPNG().AsStream();
					}
				}
			});

			return stream;
		}

		/// <summary>
		/// Runs if permission is granted.
		/// </summary>
		/// <returns>The if permission is granted.</returns>
		/// <param name="action">Action.</param>
		async Task RunIfPermissionIsGranted(Action action)
		{
			await AddressBook.RequestPermission().ContinueWith(t => {
				if (t.Result)
				{
					action();
				}
			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		/// <summary>
		/// Gets the address book.
		/// </summary>
		/// <value>The address book.</value>
		public AddressBook AddressBook {
			get;
			private set;
		}
	}
}