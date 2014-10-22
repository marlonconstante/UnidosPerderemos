using System;
using System.Threading.Tasks;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Services
{
	public interface IUserService
	{
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
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		User CurrentUser {
			get;
		}
	}
}