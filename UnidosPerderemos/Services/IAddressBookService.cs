using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Services
{
	public interface IAddressBookService
	{
		/// <summary>
		/// Finds all contacts.
		/// </summary>
		/// <returns>The all contacts.</returns>
		Task<IList<PersonContact>> FindAllContacts();

		/// <summary>
		/// Gets the thumbnail.
		/// </summary>
		/// <returns>The thumbnail.</returns>
		/// <param name="id">Identifier.</param>
		Task<Stream> GetThumbnail(string id);
	}
}