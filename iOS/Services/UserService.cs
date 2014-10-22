using System;
using UnidosPerderemos.Services;
using System.Threading.Tasks;
using Parse;
using UnidosPerderemos.Models;
using UnidosPerderemos.iOS.Utils;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.UserService))]
namespace UnidosPerderemos.iOS.Services
{
	public class UserService : IUserService
	{
		/// <summary>
		/// Login the specified user.
		/// </summary>
		/// <param name="user">User.</param>
		public async Task<bool> Login(User user)
		{
			try
			{
				var parseUser = await ParseUser.LogInAsync(user.Username, user.Password);

				return parseUser.IsAuthenticated;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		/// <summary>
		/// Signs up.
		/// </summary>
		/// <returns>The up.</returns>
		/// <param name="user">User.</param>
		public async Task<bool> SignUp(User user)
		{
			try
			{
				var parseUser = user.ToParseObject<ParseUser>();
				await parseUser.SignUpAsync();

				return parseUser.IsAuthenticated;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		public User CurrentUser {
			get {
				return ParseUser.CurrentUser.ToDomain<User>();
			}
		}
	}
}