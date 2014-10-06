﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace UnidosPerderemos
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