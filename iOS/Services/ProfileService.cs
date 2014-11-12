using System;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using System.Threading.Tasks;
using UnidosPerderemos.iOS.Utils;
using Parse;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.ProfileService))]
namespace UnidosPerderemos.iOS.Services
{
	public class ProfileService : IProfileService
	{
		/// <summary>
		/// Load this instance.
		/// </summary>
		public async Task<UserProfile> Load()
		{
			try
			{
				var query = ParseObject.GetQuery("UserProfile").WhereEqualTo("user", ParseUser.CurrentUser);
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
				userProfile.UserName = ParseUser.CurrentUser.Get<string>("name");

				var parseObject = userProfile.ToParseObject<ParseObject>();
				await parseObject.SaveAsync();

				userProfile.ObjectId = parseObject.ObjectId;

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}