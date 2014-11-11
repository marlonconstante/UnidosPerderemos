using System;
using UnidosPerderemos.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnidosPerderemos.Models;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.ProgressService))]
namespace UnidosPerderemos.iOS.Services
{
	public class ProgressService : IProgressService
	{
		/// <summary>
		/// Loads the daily.
		/// </summary>
		/// <returns>The daily.</returns>
		public async Task<DailyProgress> LoadDaily() {
			return null;
		}

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>The all.</returns>
		/// <param name="user">User.</param>
		public async Task<IList<IProgress>> FindAll(User user) {
			return new List<IProgress>();
		}

		/// <summary>
		/// Save the specified progress.
		/// </summary>
		/// <param name="progress">Progress.</param>
		public async Task<bool> Save(IProgress progress) {
			return true;
		}
	}
}