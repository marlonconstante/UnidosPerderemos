using System;
using UnidosPerderemos.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnidosPerderemos.Models;
using UnidosPerderemos.iOS.Utils;
using Parse;
using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.ProgressService))]
namespace UnidosPerderemos.iOS.Services
{
	public class ProgressService : IProgressService
	{
		/// <summary>
		/// Load this instance.
		/// </summary>
		public async Task<UserProgress> Load()
		{
			try
			{
				var query = ParseObject.GetQuery("UserProgress")
					.WhereEqualTo("user", ParseUser.CurrentUser)
					.WhereEqualTo("date", DateTime.Now.Date);

				var parseObject = await query.FirstOrDefaultAsync();
				if (parseObject != null)
				{
					return parseObject.ToDomain<UserProgress>();
				}
			}
			catch (Exception ex)
			{
				// Ignora...
			}
			return new UserProgress();
		}

		/// <summary>
		/// Find the specified user.
		/// </summary>
		/// <param name="user">User.</param>
		public async Task<IEnumerable<UserProgress>> Find(User user)
		{
			var result = new List<UserProgress>();

			try
			{
				var query = ParseObject.GetQuery("UserProgress")
					.WhereEqualTo("user", user.ToParseObject<ParseUser>())
					.OrderByDescending((p) => p.Get<DateTime>("date"));

				foreach (var parseObject in await query.FindAsync())
				{
					result.Add(parseObject.ToDomain<UserProgress>());
				}
			}
			catch (Exception ex)
			{
				result.Clear();
			}

			return result;
		}

		/// <summary>
		/// Save the specified progress.
		/// </summary>
		/// <param name="progress">Progress.</param>
		/// <param name="userProgress">User progress.</param>
		public async Task<bool> Save(UserProgress userProgress)
		{
			try
			{
				userProgress.Date = DateTime.Now.Date;

				var parseObject = userProgress.ToParseObject<ParseObject>();
				await parseObject.SaveAsync();

				userProgress.ObjectId = parseObject.ObjectId;

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}