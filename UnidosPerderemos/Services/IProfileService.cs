using System;
using UnidosPerderemos.Models;
using System.Threading.Tasks;

namespace UnidosPerderemos.Services
{
	public interface IProfileService
	{
		/// <summary>
		/// Load this instance.
		/// </summary>
		Task<UserProfile> Load();

		/// <summary>
		/// Save the specified userProfile.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		Task<bool> Save(UserProfile userProfile);
	}
}