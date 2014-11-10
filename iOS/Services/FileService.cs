using System;
using UnidosPerderemos.Services;
using System.Threading.Tasks;
using UnidosPerderemos.Models;
using UnidosPerderemos.iOS.Utils;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.FileService))]
namespace UnidosPerderemos.iOS.Services
{
	public class FileService : IFileService
	{
		/// <summary>
		/// Download the specified file.
		/// </summary>
		/// <param name="file">File.</param>
		public async Task Download(RemoteFile file)
		{
			await file.Download();
		}
	}
}