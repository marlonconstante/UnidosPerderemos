using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnidosPerderemos
{
	public interface IAddressBookService
	{
		/// <summary>
		/// Finds all contacts.
		/// </summary>
		/// <returns>The all contacts.</returns>
		Task<IList<PersonContact>> FindAllContacts();
	}
}