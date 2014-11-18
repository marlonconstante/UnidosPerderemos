using System;
using UnidosPerderemos.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnidosPerderemos.Services
{
	public interface IProgressService
	{
		/// <summary>
		/// Load this instance.
		/// </summary>
		Task<UserProgress> Load();

		/// <summary>
		/// Find the specified user.
		/// </summary>
		/// <param name="user">User.</param>
		Task<IEnumerable<UserProgress>> Find(User user);

		/// <summary>
		/// Save the specified progress.
		/// </summary>
		/// <param name="progress">Progress.</param>
		Task<bool> Save(UserProgress progress);
	}
}