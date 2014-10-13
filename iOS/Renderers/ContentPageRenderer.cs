using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos;
using UnidosPerderemos.Core.Styles;

[assembly: ExportRenderer(typeof(ContentPage), typeof(UnidosPerderemos.iOS.ContentPageRenderer))]
namespace UnidosPerderemos.iOS
{
	public class ContentPageRenderer : PageRenderer
	{
		public ContentPageRenderer()
		{
		}

		/// <summary>
		/// Views the will appear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			if (ControlPage != null)
			{
				Target.NavigationBarHidden = !ControlPage.IsShowNavigationBar();
				Application.StatusBarHidden = !ControlPage.IsShowStatusBar();

				var lightStyle = StatusBarStyle.Light == ControlPage.PreferredStatusBarStyle();
				Application.StatusBarStyle = lightStyle ? UIStatusBarStyle.LightContent : UIStatusBarStyle.Default;
			}
		}

		/// <summary>
		/// Gets the application.
		/// </summary>
		/// <value>The application.</value>
		UIApplication Application {
			get {
				return UIApplication.SharedApplication;
			}
		}

		/// <summary>
		/// Gets the control page.
		/// </summary>
		/// <value>The control page.</value>
		IControlPage ControlPage {
			get {
				return Source as IControlPage;
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		ContentPage Source {
			get {
				return Element as ContentPage;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UINavigationController Target {
			get {
				return NavigationController;
			}
		}
	}
}