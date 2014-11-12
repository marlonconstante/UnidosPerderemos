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
		/// Loads the daily.
		/// </summary>
		/// <returns>The daily.</returns>
		public async Task<UserProgress> LoadDaily()
		{
			try
			{
				var query = ParseObject.GetQuery("UserProgress")
					.WhereEqualTo("type", ProgressType.Daily.ToString())
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
			return DailyUserProgress;
		}

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>The all.</returns>
		/// <param name="user">User.</param>
		public async Task<IEnumerable<UserProgress>> FindAll(User user)
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

		/// <summary>
		/// Gets the daily user progress.
		/// </summary>
		/// <value>The daily user progress.</value>
		UserProgress DailyUserProgress {
			get {
				return new UserProgress {
					Type = ProgressType.Daily
				};
			}
		}
	}
}