using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(UnidosPerderemos.iOS.Renderers.Pages.TabbedPageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Pages
{
	public class TabbedPageRenderer : TabbedRenderer
	{
		public TabbedPageRenderer()
		{
		}

		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TabBarAppearance.BackgroundImage = EmptyImage;
			TabBarAppearance.ShadowImage = EmptyImage;
		}

		/// <summary>
		/// Views the will appear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			if (!Initialized)
			{
				foreach (var view in Target.Subviews)
				{
					view.RemoveFromSuperview();
				}

				foreach (var item in Target.Items)
				{
					var button = new UIButton {
						BackgroundColor = UIColor.White.ColorWithAlpha(0.2f)
					};

					button.SetImage(item.Image, UIControlState.Normal);
					button.SetImage(item.Image, UIControlState.Highlighted);

					Target.Add(button);
					Buttons.Add(button);
				}

				SelectButton(Source.Children.IndexOf(Source.CurrentPage));

				Initialized = true;
			}

			foreach (var button in Buttons)
			{
				button.TouchUpInside += ChangeCurrentPage;
			}
		}

		/// <summary>
		/// Views the will disappear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			foreach (var button in Buttons)
			{
				button.TouchUpInside -= ChangeCurrentPage;
			}
		}

		/// <summary>
		/// Changes the current page.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void ChangeCurrentPage(object sender, EventArgs args)
		{
			var indexOf = Buttons.IndexOf(sender as UIButton);

			Source.CurrentPage = Source.Children[indexOf];
			SelectButton(indexOf);
		}

		/// <summary>
		/// Selects the button.
		/// </summary>
		/// <param name="indexOf">Index of.</param>
		void SelectButton(int indexOf)
		{
			for (var index = 0; index < Buttons.Count; index++)
			{
				Buttons[index].BackgroundColor = UIColor.White.ColorWithAlpha((index == indexOf) ? 0.3f : 0.2f);
			}
		}

		/// <summary>
		/// Views the will layout subviews.
		/// </summary>
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();

			Target.Frame = new RectangleF(0f, ScreenSize.Height - TabBarHeight - TopBarHeight, ScreenSize.Width, TabBarHeight);

			for (var index = 0; index < Buttons.Count; index++)
			{
				Buttons[index].Frame = new RectangleF(index * (TabBarItemWidth + 1f), 0f, TabBarItemWidth - 1f, TabBarHeight);
			}
		}

		/// <summary>
		/// Gets the buttons.
		/// </summary>
		/// <value>The buttons.</value>
		public IList<UIButton> Buttons {
			get;
		} = new List<UIButton>();

		/// <summary>
		/// Gets the height of the top bar.
		/// </summary>
		/// <value>The height of the top bar.</value>
		float TopBarHeight {
			get {
				return StatusBarSize.Height + NavigationBarSize.Height;
			}
		}

		/// <summary>
		/// Gets the height of the tab bar.
		/// </summary>
		/// <value>The height of the tab bar.</value>
		float TabBarHeight {
			get {
				return 52f;
			}
		}

		/// <summary>
		/// Gets the width of the tab bar item.
		/// </summary>
		/// <value>The width of the tab bar item.</value>
		float TabBarItemWidth {
			get {
				return ScreenSize.Width / Target.Items.Length;
			}
		}

		/// <summary>
		/// Gets the size of the status bar.
		/// </summary>
		/// <value>The size of the status bar.</value>
		SizeF StatusBarSize {
			get {
				return UIApplication.SharedApplication.StatusBarFrame.Size;
			}
		}

		/// <summary>
		/// Gets the size of the navigation bar.
		/// </summary>
		/// <value>The size of the navigation bar.</value>
		SizeF NavigationBarSize {
			get {
				if (NavigationController == null)
				{
					return SizeF.Empty;
				}
				else
				{
					return NavigationController.NavigationBar.Frame.Size;
				}
			}
		}

		/// <summary>
		/// Gets the size of the screen.
		/// </summary>
		/// <value>The size of the screen.</value>
		SizeF ScreenSize {
			get {
				return UIScreen.MainScreen.Bounds.Size;
			}
		}

		/// <summary>
		/// Gets the empty image.
		/// </summary>
		/// <value>The empty image.</value>
		UIImage EmptyImage {
			get;
		} = new UIImage();

		/// <summary>
		/// Gets the tab bar appearance.
		/// </summary>
		/// <value>The tab bar appearance.</value>
		UITabBar.UITabBarAppearance TabBarAppearance {
			get {
				return UITabBar.Appearance;
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		TabbedPage Source {
			get {
				return Element as TabbedPage;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UITabBar Target {
			get {
				return TabBar;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnidosPerderemos.iOS.Renderers.Pages.TabbedPageRenderer"/>
		/// is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized {
			get;
			set;
		} = false;
	}
}