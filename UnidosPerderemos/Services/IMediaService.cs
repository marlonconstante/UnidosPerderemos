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
		/// <param name="maxSize">Max size.</param>
		Task<Stream> GetPhoto(Size maxSize);
	}
}