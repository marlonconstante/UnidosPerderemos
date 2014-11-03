using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using System.Drawing;

[assembly: ExportRenderer(typeof(ContentPage), typeof(UnidosPerderemos.iOS.Renderers.Pages.ContentPageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Pages
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
				NavigationController.NavigationBarHidden = !ControlPage.IsShowNavigationBar();
				Application.StatusBarHidden = !ControlPage.IsShowStatusBar();

				var lightStyle = StatusBarStyle.Light == ControlPage.PreferredStatusBarStyle();
				Application.StatusBarStyle = lightStyle ? UIStatusBarStyle.LightContent : UIStatusBarStyle.Default;

				Target.InsertSubview(new UIImageView() {
					Image = UIImage.FromFile("Background.jpg"),
					ContentMode = UIViewContentMode.Left,
					Frame = new RectangleF(-220f, -80f, ScreenBounds.Width, ScreenBounds.Height)
				}, 0);
			}
		}

		/// <summary>
		/// Gets the screen bounds.
		/// </summary>
		/// <value>The screen bounds.</value>
		RectangleF ScreenBounds {
			get {
				return UIScreen.MainScreen.Bounds;
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
		UIView Target {
			get {
				return View;
			}
		}
	}
}