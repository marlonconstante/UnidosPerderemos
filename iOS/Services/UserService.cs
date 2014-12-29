using System;
using UnidosPerderemos.Services;
using System.Threading.Tasks;
using Parse;
using UnidosPerderemos.Models;
using UnidosPerderemos.iOS.Utils;
using MonoTouch.FacebookConnect;
using UnidosPerderemos.Utils;
using System.Security.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.UserService))]
namespace UnidosPerderemos.iOS.Services
{
	public class UserService : IUserService
	{
		/// <summary>
		/// Logins the with facebook.
		/// </summary>
		/// <param name="successfulAction">Successful action.</param>
		/// <param name="faultAction">Fault action.</param>
		public void LoginWithFacebook(Action successfulAction, Action faultAction)
		{
			FBSession.OpenActiveSession(new string[] { "public_profile", "email", "user_friends" }, true, async (session, status, error) => {
				try
				{
					var token = session.AccessTokenData;
					if (token != null)
					{
						var response = await FBRequest.ForMe.StartAsync();
						var result = response.Result as FBGraphObject;
						var userId = result["id"].ToString();

						var parseUser = await ParseFacebookUtils.LogInAsync(userId, token.AccessToken, token.ExpirationDate);
						if (parseUser.IsAuthenticated)
						{
							successfulAction();

							parseUser["facebookId"] = userId;
							parseUser["name"] = result["name"].ToString();
							parseUser["gender"] = result["gender"].ToString().ToFirstUppercase();
							parseUser["emailAddress"] = result["email"].ToString();
							parseUser.SaveAsync();
						}
						else
						{
							throw new InvalidCredentialException();
						}
					}
				}
				catch (Exception ex)
				{
					faultAction();
				}
			});
		}

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
		/// Logout this instance.
		/// </summary>
		public void Logout()
		{
			ParseUser.LogOut();
			App.Instance.CurrentUserProfile = null;
		}

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		public User CurrentUser {
			get {
				return ParseUser.CurrentUser?.ToDomain<User>();
			}
		}
	}
}