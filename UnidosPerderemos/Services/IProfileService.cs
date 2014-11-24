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
		/// Loads the friend.
		/// </summary>
		/// <returns>The friend.</returns>
		/// <param name="facebookId">Facebook identifier.</param>
		Task<UserProfile> LoadFriend(string facebookId);

		/// <summary>
		/// Save the specified userProfile.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		Task<bool> Save(UserProfile userProfile);
	}
}