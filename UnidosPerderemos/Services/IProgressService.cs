using System;
using UnidosPerderemos.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnidosPerderemos.Services
{
	public interface IProgressService
	{
		/// <summary>
		/// Loads the daily.
		/// </summary>
		/// <returns>The daily.</returns>
		Task<DailyProgress> LoadDaily();

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>The all.</returns>
		/// <param name="user">User.</param>
		Task<IEnumerable<IProgress>> FindAll(User user);

		/// <summary>
		/// Save the specified progress.
		/// </summary>
		/// <param name="progress">Progress.</param>
		Task<bool> Save(IProgress progress);
	}
}