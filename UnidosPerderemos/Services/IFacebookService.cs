using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Services
{
	public interface IFacebookService
	{
		/// <summary>
		/// Finds all friends.
		/// </summary>
		/// <returns>The all friends.</returns>
		Task<IList<PersonFacebook>> FindAllFriends();
	}
}