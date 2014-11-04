using System;
using UnidosPerderemos.Core.Styles;

namespace UnidosPerderemos.Core.Pages
{
	public interface IControlPage
	{
		/// <summary>
		/// Preferreds the status bar style.
		/// </summary>
		/// <returns>The status bar style.</returns>
		StatusBarStyle PreferredStatusBarStyle();

		/// <summary>
		/// Determines whether this instance is show navigation bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show navigation bar; otherwise, <c>false</c>.</returns>
		bool IsShowNavigationBar();

		/// <summary>
		/// Determines whether this instance is show status bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show status bar; otherwise, <c>false</c>.</returns>
		bool IsShowStatusBar();

		/// <summary>
		/// Backgrounds the name of the image.
		/// </summary>
		/// <returns>The image name.</returns>
		string BackgroundImageName();
	}
}