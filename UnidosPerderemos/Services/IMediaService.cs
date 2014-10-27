using System;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;

namespace UnidosPerderemos.Services
{
	public interface IMediaService
	{
		/// <summary>
		/// Gets the photo.
		/// </summary>
		/// <returns>The photo.</returns>
		Task<Stream> GetPhoto();
	}
}