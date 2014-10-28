using System;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using System.Threading.Tasks;
using UnidosPerderemos.iOS.Utils;
using Parse;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.UserProfileService))]
namespace UnidosPerderemos.iOS.Services
{
	public class UserProfileService : IUserProfileService
	{
		/// <summary>
		/// Save the specified userProfile.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public async Task Save(UserProfile userProfile)
		{
			var parseObject = userProfile.ToParseObject<ParseObject>();
			await parseObject.SaveAsync();

			userProfile.ObjectId = parseObject.ObjectId;
		}
	}
}