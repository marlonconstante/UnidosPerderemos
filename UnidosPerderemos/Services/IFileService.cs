using System;
using UnidosPerderemos.Models;
using System.Threading.Tasks;

namespace UnidosPerderemos.Services
{
	public interface IFileService
	{
		/// <summary>
		/// Download the specified file.
		/// </summary>
		/// <param name="file">File.</param>
		Task Download(RemoteFile file);
	}
}