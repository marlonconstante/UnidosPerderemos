using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Parse;

namespace UnidosPerderemos.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		/// <summary>
		/// Finisheds the launching.
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="app">App.</param>
		/// <param name="options">Options.</param>
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

			ParseClient.Initialize("N13dhq1tjbvEsofWXmznVl3UwduSAz8DqxbVYAXo", "3rHleZk64cDu9qssw8PGo738aocb9rYUStNFft7a");

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
}