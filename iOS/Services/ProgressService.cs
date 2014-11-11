﻿using System;
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
				var query = ParseObject.GetQuery("DailyProgress").WhereEqualTo("user", ParseUser.CurrentUser);
				var parseObject = await query.FirstOrDefaultAsync() ?? new ParseObject("DailyProgress");

				return parseObject.ToDomain<UserProgress>();
			}
			catch (Exception ex)
			{
				return new UserProgress();
			}
		}

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>The all.</returns>
		/// <param name="user">User.</param>
		public async Task<IEnumerable<UserProgress>> FindAll(User user)
		{
			var result = await Find<UserProgress>(user);
			return result.OrderByDescending((p) => p.Date);
		}

		/// <summary>
		/// Find the specified user.
		/// </summary>
		/// <param name="user">User.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		async Task<IEnumerable<UserProgress>> Find<T>(User user) where T : UserProgress
		{
			var result = new List<UserProgress>();

			try
			{
				var query = ParseObject.GetQuery(typeof(T).Name).WhereEqualTo("user", user.ToParseObject<ParseUser>());
				var parseObjects = await query.FindAsync();
				foreach (var parseObject in parseObjects)
				{
					result.Add(parseObject.ToDomain<T>());
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
		public async Task<bool> Save(UserProgress progress)
		{
			try
			{
				if (progress.Date == null)
				{
					progress.Date = new DateTime();
				}

				var parseObject = progress.ToParseObject<ParseObject>();
				await parseObject.SaveAsync();

				progress.ObjectId = parseObject.ObjectId;

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}