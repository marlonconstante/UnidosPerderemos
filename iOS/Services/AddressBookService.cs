using System;
using System.Collections.Generic;
using Xamarin.Contacts;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.AddressBookService))]
namespace UnidosPerderemos.iOS
{
	public class AddressBookService : IAddressBookService
	{
		public AddressBookService()
		{
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
			var book = new AddressBook();
			var contacts = new List<PersonContact>();

			await book.RequestPermission().ContinueWith(t => {
				if (t.Result)
				{
					foreach (var contact in book)
					{
						contacts.Add(new PersonContact {
							Name = contact.DisplayName,
							Phones = GetPhones(contact),
							Emails = GetEmails(contact)
						});
					}
				}
			}, TaskScheduler.FromCurrentSynchronizationContext());

			return contacts.OrderBy(c => c.Name).ToList();
		}
	}
}