using System;
using UnidosPerderemos.Models;
using System.Threading.Tasks;

namespace UnidosPerderemos.Services
{
	public interface IUserProfileService
	{
		/// <summary>
		/// Save the specified userProfile.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		Task Save(UserProfile userProfile);
	}
}