using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Parse;
using MonoTouch.FacebookConnect;

namespace UnidosPerderemos.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		/// <summary>
		/// The facebook app identifier.
		/// </summary>
		const string FacebookAppId = "1525866027660551";

		/// <summary>
		/// The display name.
		/// </summary>
		const string DisplayName = "UnidosPerderemos";

		/// <summary>
		/// The parse app identifier.
		/// </summary>
		const string ParseAppId = "N13dhq1tjbvEsofWXmznVl3UwduSAz8DqxbVYAXo";

		/// <summary>
		/// The parse dotnet key.
		/// </summary>
		const string ParseDotnetKey = "3rHleZk64cDu9qssw8PGo738aocb9rYUStNFft7a";

		/// <summary>
		/// The window.
		/// </summary>
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

			FBSettings.DefaultAppID = FacebookAppId;
			FBSettings.DefaultDisplayName = DisplayName;

			ParseClient.Initialize(ParseAppId, ParseDotnetKey);
			ParseFacebookUtils.Initialize(FacebookAppId);

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();
			
			return true;
		}

		/// <summary>
		/// Opens the URL.
		/// </summary>
		/// <returns><c>true</c>, if URL was opened, <c>false</c> otherwise.</returns>
		/// <param name="application">Application.</param>
		/// <param name="url">URL.</param>
		/// <param name="sourceApplication">Source application.</param>
		/// <param name="annotation">Annotation.</param>
		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return FBSession.ActiveSession.HandleOpenURL(url);
		}

		/// <Docs>Reference to the UIApplication that invoked this delegate method.</Docs>
		/// <remarks>Because iOS applications should be designed to be long-lived, with many transitions between foreground processing
		/// and suspension or background processing, this method is generally the proper place to ensure that all the
		/// resources and state information for foreground processing are available and properly configured.</remarks>
		/// <img href="UIApplicationDelegate.Lifecycle.png"></img>
		/// <altmember cref="M:MonoTouch.UIKit.UIApplicationDelegate.OnResignActivation"></altmember>
		/// <summary>
		/// Raises the activated event.
		/// </summary>
		/// <param name="application">Application.</param>
		public override void OnActivated(UIApplication application)
		{
			FBSession.ActiveSession.HandleDidBecomeActive();
		}
	}
}