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
		Task<UserProgress> LoadDaily();

		/// <summary>
		/// Find the specified user and type.
		/// </summary>
		/// <param name="user">User.</param>
		/// <param name="type">Type.</param>
		Task<IEnumerable<UserProgress>> Find(User user, ProgressType type);

		/// <summary>
		/// Save the specified progress.
		/// </summary>
		/// <param name="progress">Progress.</param>
		Task<bool> Save(UserProgress progress);
	}
}