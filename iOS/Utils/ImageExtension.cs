using System;
using System.IO;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace UnidosPerderemos.iOS.Utils
{
	public static class ImageExtension
	{
		/// <summary>
		/// The compression quality.
		/// </summary>
		const float CompressionQuality = 0.7f;

		/// <summary>
		/// Resizes the image.
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="stream">Stream.</param>
		/// <param name="maxSize">Max size.</param>
		public static Stream ResizeImage(this Stream stream, SizeF maxSize)
		{
			using (var originalImage = stream.LoadImage())
			{
				using (var resizedImage = originalImage.Scale(originalImage.PreferredSize(maxSize)))
				{
					return new MemoryStream(resizedImage.AsJPEG(CompressionQuality).ToArray());
				}
			}
		}

		/// <summary>
		/// Loads the image.
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="stream">Stream.</param>
		public static UIImage LoadImage(this Stream stream)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (stream)
				{
					stream.CopyTo(memoryStream);
					return new UIImage(NSData.FromArray(memoryStream.ToArray()));
				}
			}
		}

		/// <summary>
		/// Preferreds the size.
		/// </summary>
		/// <returns>The size.</returns>
		/// <param name="image">Image.</param>
		/// <param name="maxSize">Max size.</param>
		public static SizeF PreferredSize(this UIImage image, SizeF maxSize)
		{
			var size = image.Size;
			var ratio = Math.Min(maxSize.Width / size.Width, maxSize.Height / size.Height);

			return new SizeF(size.Width * ratio, size.Height * ratio);
		}
	}
}