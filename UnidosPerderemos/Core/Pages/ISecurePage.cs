using System;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Core.Pages
{
	public interface ISecurePage
	{
		/// <summary>
		/// Raises the user profile loaded event.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		void OnUserProfileLoaded(UserProfile userProfile);
	}
}