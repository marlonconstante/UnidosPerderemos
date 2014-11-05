﻿using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;

[assembly: ExportRenderer(typeof(ContentPage), typeof(UnidosPerderemos.iOS.Renderers.Pages.ContentPageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Pages
{
	public class ContentPageRenderer : PageRenderer
	{
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

				AddBackgroundImage(ControlPage.BackgroundImageName());
			}
		}

		/// <summary>
		/// Adds the background image.
		/// </summary>
		/// <param name="imageName">Image name.</param>
		void AddBackgroundImage(string imageName)
		{
			if (!string.IsNullOrEmpty(imageName))
			{
				Target.InsertSubview(new UIImageView() {
					Image = UIImage.FromFile(imageName),
					AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
					ContentMode = UIViewContentMode.ScaleAspectFill,
					Frame = UIScreen.MainScreen.Bounds
				}, 0);
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