using System;
using System.Threading.Tasks;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Services
{
	public interface IUserService
	{
		/// <summary>
		/// Logins the with facebook.
		/// </summary>
		/// <param name="successfulAction">Successful action.</param>
		/// <param name="faultAction">Fault action.</param>
		void LoginWithFacebook(Action successfulAction, Action faultAction);

		/// <summary>
		/// Login the specified user.
		/// </summary>
		/// <param name="user">User.</param>
		Task<bool> Login(User user);

		/// <summary>
		/// Signs up.
		/// </summary>
		/// <returns>The up.</returns>
		/// <param name="user">User.</param>
		Task<bool> SignUp(User user);

		/// <summary>
		/// Logout this instance.
		/// </summary>
		void Logout();

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		User CurrentUser {
			get;
		}
	}
}