﻿using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

[assembly: ExportRenderer(typeof(ContentPage), typeof(UnidosPerderemos.iOS.Renderers.Pages.ContentPageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Pages
{
	public class ContentPageRenderer : PageRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected override void OnElementChanged(VisualElementChangedEventArgs args)
		{
			base.OnElementChanged(args);

			if (ControlPage != null)
			{
				AddBackgroundImage(ControlPage.BackgroundImageName());
			}
			AddSwipeGestureRecognizer();
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
			}

			AddNavigationItems();
			ScrollToTop();
			UpdateBackgroundFrame();
		}

		/// <summary>
		/// Wills the rotate.
		/// </summary>
		/// <param name="toInterfaceOrientation">To interface orientation.</param>
		/// <param name="duration">Duration.</param>
		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate(toInterfaceOrientation, duration);

			ScrollToTop(duration);
			UpdateBackgroundFrame(duration);
		}

		/// <summary>
		/// Scrolls to top.
		/// </summary>
		/// <param name="duration">Duration.</param>
		void ScrollToTop(double duration = 0d)
		{
			UIView.Animate(duration, () => {
				foreach (var view in Target.Subviews.Where((v) => v is UIScrollView))
				{
					var scrollView = view as UIScrollView;
					scrollView.ScrollRectToVisible(new RectangleF(0f, 0f, 1f, 1f), false);
				}
			});
		}

		/// <summary>
		/// Updates the background frame.
		/// </summary>
		/// <param name="duration">Duration.</param>
		void UpdateBackgroundFrame(double duration = 0d)
		{
			var frame = BackgroundImageView.Frame;
			var max = Math.Max(frame.Width, frame.Height);
			var min = Math.Min(frame.Width, frame.Height);

			UIView.Animate(duration, () => {
				var isLandscape = CurrentOrientation.IsLandscape();
				BackgroundImageView.Frame = new RectangleF(0f, 0f, isLandscape ? max : min, isLandscape ? min : max);
			});
		}

		/// <summary>
		/// Adds the background image.
		/// </summary>
		/// <param name="imageName">Image name.</param>
		void AddBackgroundImage(string imageName)
		{
			if (!string.IsNullOrEmpty(imageName))
			{
				BackgroundImageView.Image = UIImage.FromFile(imageName);
				Target.InsertSubview(BackgroundImageView, 0);
			}
		}

		/// <summary>
		/// Adds the navigation items.
		/// </summary>
		void AddNavigationItems()
		{
			var toolbarItems = Source.ToolbarItems;
			if (toolbarItems.Count > 0)
			{
				var leftItems = new List<UIBarButtonItem>();
				var rightItems = new List<UIBarButtonItem>();
				foreach (var item in toolbarItems)
				{
					var items = (item is LeftToolbarItem) ? leftItems : rightItems;
					items.Add(item.ToUIBarButtonItem());
				}
				TopNavigationItem.LeftBarButtonItems = leftItems.ToArray();
				TopNavigationItem.RightBarButtonItems = rightItems.ToArray();
			}
		}

		/// <summary>
		/// Adds the swipe gesture recognizer.
		/// </summary>
		void AddSwipeGestureRecognizer()
		{
			Target.AddGestureRecognizer(new UISwipeGestureRecognizer(() => {
				if (TopViewController != InitialViewController)
				{
					NavigationController.PopViewControllerAnimated(true);
				}
			}) {
				Direction = UISwipeGestureRecognizerDirection.Right
			});
		}

		/// <summary>
		/// Gets the current orientation.
		/// </summary>
		/// <value>The current orientation.</value>
		UIDeviceOrientation CurrentOrientation {
			get {
				return UIDevice.CurrentDevice.Orientation;
			}
		}

		/// <summary>
		/// Gets the background image view.
		/// </summary>
		/// <value>The background image view.</value>
		UIImageView BackgroundImageView {
			get;
		} = new UIImageView() {
			ContentMode = UIViewContentMode.ScaleAspectFill,
			Frame = UIScreen.MainScreen.Bounds
		};

		/// <summary>
		/// Gets the top navigation item.
		/// </summary>
		/// <value>The top navigation item.</value>
		UINavigationItem TopNavigationItem {
			get {
				return TopViewController.NavigationItem;
			}
		}

		/// <summary>
		/// Gets the top view controller.
		/// </summary>
		/// <value>The top view controller.</value>
		UIViewController TopViewController {
			get {
				return NavigationController.TopViewController;
			}
		}

		/// <summary>
		/// Gets the initial view controller.
		/// </summary>
		/// <value>The initial view controller.</value>
		UIViewController InitialViewController {
			get {
				return NavigationController.ViewControllers[0];
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