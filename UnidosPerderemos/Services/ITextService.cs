using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Services
{
	public interface ITextService
	{
		/// <summary>
		/// Preferreds the size.
		/// </summary>
		/// <returns>The size.</returns>
		/// <param name="text">Text.</param>
		/// <param name="font">Font.</param>
		/// <param name="maxSize">Max size.</param>
		Size PreferredSize(string text, Font font, Size maxSize);
	}
}