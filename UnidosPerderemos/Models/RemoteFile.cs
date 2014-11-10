using System;
using System.IO;
using System.Net;

namespace UnidosPerderemos.Models
{
	public class RemoteFile
	{
		public RemoteFile()
		{
		}

		/// <summary>
		/// Sets the full name.
		/// </summary>
		/// <value>The full name.</value>
		public string FullName {
			set {
				Name = value.Substring(value.LastIndexOf("-") + 1);
			}
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>The URL.</value>
		public string Url {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the stream.
		/// </summary>
		/// <value>The stream.</value>
		public Stream Stream {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is loaded.
		/// </summary>
		/// <value><c>true</c> if this instance is loaded; otherwise, <c>false</c>.</value>
		public bool IsLoaded {
			get {
				return Stream != null;
			}
		}
	}
}