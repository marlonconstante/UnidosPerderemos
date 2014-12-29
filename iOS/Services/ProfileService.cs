using System;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using System.Threading.Tasks;
using UnidosPerderemos.iOS.Utils;
using Parse;
using System.Threading;
using System.Collections.Generic;

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
			var parameters = new Dictionary<string, object>();
			parameters.Add("maxDate", DateTime.Now.AddDays(1d).Date);

			return await FirstOrDefault(() => {
				return ParseCloud.CallFunctionAsync<ParseObject>("LoadUserProfile", parameters);
			});
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

			return await FirstOrDefault(() => {
				return query.FirstOrDefaultAsync();
			});
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
		/// <param name="function">Function.</param>
		async Task<UserProfile> FirstOrDefault(Func<Task<ParseObject>> function)
		{
			try
			{
				var parseObject = await function() ?? new ParseObject("UserProfile");
				return parseObject.ToDomain<UserProfile>();
			}
			catch (Exception ex)
			{
				return new UserProfile();
			}
		}

		/// <summary>
		/// Reset the specified userProfile.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public async Task<bool> Reset(UserProfile userProfile)
		{
			var parameters = new Dictionary<string, object>();
			parameters.Add("inactivationDate", DateTime.Now.Date);

			try
			{
				await ParseCloud.CallFunctionAsync<Task>("ResetUserProfile", parameters);

				userProfile.StartDate = DateTime.Now.Date;
				userProfile.DateLastWeekly = DateTime.Now.Date;
				userProfile.DateLastDaily = DateTime.MinValue;
				userProfile.DateLastPrize = null;
				userProfile.WeeklyDedication = 0L;

				return true;
			}
			catch (Exception ex)
			{
				return false;
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
		void FinalizeRegistration()
		{
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