using System;
using Xamarin.Forms;
using MonoTouch.Foundation;
using Xamarin.Forms.Platform.iOS;
using UnidosPerderemos.Services;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.TextService))]
namespace UnidosPerderemos.iOS.Services
{
	public class TextService : ITextService
	{
		/// <summary>
		/// Preferreds the size.
		/// </summary>
		/// <returns>The size.</returns>
		/// <param name="text">Text.</param>
		/// <param name="font">Font.</param>
		public Size PreferredSize(string text, Font font) {

			var stringSize = new NSString(text).StringSize(font.ToUIFont());
			return new Size(stringSize.Width, stringSize.Height);
		}
	}
}