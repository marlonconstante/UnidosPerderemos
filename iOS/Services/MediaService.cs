using System;
using UnidosPerderemos.Services;
using Xamarin.Forms;
using Xamarin.Media;
using System.Threading.Tasks;
using System.IO;
using UnidosPerderemos.iOS.Utils;
using MonoTouch.UIKit;
using Xamarin.Forms.Platform.iOS;

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

			OpenMediaOptions();
			while (SelectedMediaSource == MediaSource.Unknown)
			{
				await Task.Delay(300);
			}

			await RunIfMediaAvailable((f) => {
				stream = f.GetStream().ResizeImage(maxSize.ToSizeF());
			});

			return stream;
		}

		/// <summary>
		/// Opens the media options.
		/// </summary>
		void OpenMediaOptions()
		{
			SelectedMediaSource = MediaSource.Unknown;

			var mediaOptions = new UIActionSheet(null, null, "Cancelar", null, "Tirar foto", "Escolher foto");
			mediaOptions.Dismissed += (object sender, UIButtonEventArgs args) => {
				SelectedMediaSource = (MediaSource) args.ButtonIndex;
			};
			mediaOptions.ShowInView(UIApplication.SharedApplication.KeyWindow);
		}

		/// <summary>
		/// Runs if media available.
		/// </summary>
		/// <returns>The if media available.</returns>
		/// <param name="action">Action.</param>
		async Task RunIfMediaAvailable(Action<MediaFile> action)
		{
			if (MediaSource.Camera == SelectedMediaSource)
			{
				await RunMediaAction(MediaPicker.TakePhotoAsync(new StoreCameraMediaOptions()), action);
			}
			else if (MediaSource.Album == SelectedMediaSource)
			{
				await RunMediaAction(MediaPicker.PickPhotoAsync(), action);
			}
		}

		/// <summary>
		/// Runs the media action.
		/// </summary>
		/// <returns>The media action.</returns>
		/// <param name="task">Task.</param>
		/// <param name="action">Action.</param>
		async Task RunMediaAction(Task<MediaFile> task, Action<MediaFile> action)
		{
			await task.ContinueWith(t => {
				if (!t.IsCanceled)
				{
					action(t.Result);
				}
			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		/// <summary>
		/// Gets or sets the selected media source.
		/// </summary>
		/// <value>The selected media source.</value>
		MediaSource SelectedMediaSource {
			get;
			set;
		}

		/// <summary>
		/// Gets the media picker.
		/// </summary>
		/// <value>The media picker.</value>
		MediaPicker MediaPicker {
			get;
		} = new MediaPicker();
	}

	/// <summary>
	/// Media source.
	/// </summary>
	public enum MediaSource {
		Unknown = -1,
		Camera = 0,
		Album = 1,
		None = 2
	}
}