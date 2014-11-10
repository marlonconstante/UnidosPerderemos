using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Services
{
	/// <summary>
	/// Interface for history service.
	/// </summary>
	public interface IHistoryService
	{
		/// <summary>
		/// Finds all contacts.
		/// </summary>
		/// <returns>The all contacts.</returns>
		Task<IList<PersonContact>> FindAllContacts();
	}
}

