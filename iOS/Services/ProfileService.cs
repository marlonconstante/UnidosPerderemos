using System;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using System.Threading.Tasks;
using UnidosPerderemos.iOS.Utils;
using Parse;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.ProfileService))]
namespace UnidosPerderemos.iOS.Services
{
	public class ProfileService : IProfileService
	{
		/// <summary>
		/// The registration finished key.
		/// </summary>
		const string RegistrationFinishedKey = "isRegistrationFinished";

		/// <summary>
		/// Load this instance.
		/// </summary>
		public async Task<UserProfile> Load()
		{
			var query = ParseObject.GetQuery("UserProfile").WhereEqualTo("user", ParseUser.CurrentUser);

			return await FirstOrDefault(query);
		}

		/// <summary>
		/// Loads the friend.
		/// </summary>
		/// <returns>The friend.</returns>
		/// <param name="facebookId">Facebook identifier.</param>
		public async Task<UserProfile> LoadFriend(string facebookId)
		{
			var query = from userProfile in ParseObject.GetQuery("UserProfile")
			            join facebookUser in GetFacebookUserQuery(facebookId) on userProfile["user"] equals facebookUser
			            select userProfile;

			return await FirstOrDefault(query);
		}

		/// <summary>
		/// Gets the facebook user query.
		/// </summary>
		/// <returns>The facebook user query.</returns>
		/// <param name="facebookId">Facebook identifier.</param>
		ParseQuery<ParseUser> GetFacebookUserQuery(string facebookId)
		{
			return ParseUser.Query.WhereEqualTo("facebookId", facebookId);
		}

		/// <summary>
		/// Firsts the or default.
		/// </summary>
		/// <returns>The or default.</returns>
		/// <param name="query">Query.</param>
		async Task<UserProfile> FirstOrDefault(ParseQuery<ParseObject> query)
		{
			try
			{
				var parseObject = await query.FirstOrDefaultAsync() ?? new ParseObject("UserProfile");
				return parseObject.ToDomain<UserProfile>();
			}
			catch (Exception ex)
			{
				return new UserProfile();
			}
		}

		/// <summary>
		/// Save the specified userProfile.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public async Task<bool> Save(UserProfile userProfile)
		{
			try
			{
				await Semaphore.WaitAsync();

				userProfile.UserName = ParseUser.CurrentUser.Get<string>("name");

				var parseObject = userProfile.ToParseObject<ParseObject>();
				await parseObject.SaveAsync();

				userProfile.ObjectId = parseObject.ObjectId;

				FinalizeRegistration();

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				Semaphore.Release();
			}
		}

		/// <summary>
		/// Finalizes the registration.
		/// </summary>
		void FinalizeRegistration() {
			var isRegistrationFinished = CurrentUser.ContainsKey(RegistrationFinishedKey) && CurrentUser.Get<bool>(RegistrationFinishedKey);
			if (!isRegistrationFinished)
			{
				CurrentUser.Remove(RegistrationFinishedKey);
				CurrentUser.Add(RegistrationFinishedKey, true);
				CurrentUser.SaveAsync();
			}
		}

		/// <summary>
		/// Gets the semaphore.
		/// </summary>
		/// <value>The semaphore.</value>
		SemaphoreSlim Semaphore {
			get;
		} = new SemaphoreSlim(1);

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>The current user.</value>
		ParseUser CurrentUser {
			get {
				return ParseUser.CurrentUser;
			}
		}
	}
}