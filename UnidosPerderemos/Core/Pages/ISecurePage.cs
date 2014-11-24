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
		/// <param name="isCurrentPage">If set to <c>true</c> is current page.</param>
		void OnUserProfileLoaded(UserProfile userProfile, bool isCurrentPage);
	}
}