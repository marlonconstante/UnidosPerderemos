using System;
using UnidosPerderemos.Models;
using System.Net;
using System.IO;
using Parse;
using System.Threading.Tasks;

namespace UnidosPerderemos.iOS.Utils
{
	public static class FileExtension
	{
		/// <summary>
		/// Download the specified file.
		/// </summary>
		/// <param name="file">File.</param>
		public static async Task Download(this RemoteFile file)
		{
			if (file.IsValidUrl)
			{
				using (WebClient webClient = new WebClient())
				{
					var data = await webClient.DownloadDataTaskAsync(new Uri(file.Url));
					file.Stream = new MemoryStream(data);
				}
			}
		}

		/// <summary>
		/// Tos the parse file.
		/// </summary>
		/// <returns>The parse file.</returns>
		/// <param name="source">Source.</param>
		public static ParseFile ToParseFile(this RemoteFile source)
		{
			return new ParseFile(source.Name, source.Stream);
		}

		/// <summary>
		/// Tos the remote file.
		/// </summary>
		/// <returns>The remote file.</returns>
		/// <param name="source">Source.</param>
		public static RemoteFile ToRemoteFile(this ParseFile source)
		{
			return new RemoteFile {
				FullName = source.Name,
				Url = source.Url.AbsoluteUri
			};
		}
	}
}