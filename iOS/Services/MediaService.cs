using System;
using UnidosPerderemos.Services;
using Xamarin.Forms;
using Xamarin.Media;
using System.Threading.Tasks;
using System.IO;
using UnidosPerderemos.iOS.Utils;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.MediaService))]
namespace UnidosPerderemos.iOS.Services
{
	public class MediaService : IMediaService
	{
		/// <summary>
		/// Gets the photo.
		/// </summary>
		/// <returns>The photo.</returns>
		/// <param name="maxSize">Max size.</param>
		public async Task<Stream> GetPhoto(Size maxSize)
		{
			var stream = Stream.Null;

			await RunIfAlbumAvailable((f) => {
				var size = new System.Drawing.SizeF((float) maxSize.Width, (float) maxSize.Height);
				stream = f.GetStream().ResizeImage(size);
			});

			return stream;
		}

		/// <summary>
		/// Runs if album available.
		/// </summary>
		/// <returns>The if album available.</returns>
		/// <param name="action">Action.</param>
		async Task RunIfAlbumAvailable(Action<MediaFile> action)
		{
			await MediaPicker.PickPhotoAsync().ContinueWith(t => {
				if (!t.IsCanceled)
				{
					action(t.Result);
				}
			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		/// <summary>
		/// Gets the media picker.
		/// </summary>
		/// <value>The media picker.</value>
		MediaPicker MediaPicker {
			get;
		} = new MediaPicker();
	}
}