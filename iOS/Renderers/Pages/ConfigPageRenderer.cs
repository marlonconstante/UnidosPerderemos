using System;
using Xamarin.Forms;
using UnidosPerderemos.Views.Config;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using UnidosPerderemos.iOS.Renderers.Pages;


[assembly: ExportRenderer(typeof(ConfigPage), typeof(ConfigPageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Pages
{
	public class ConfigPageRenderer : PageRenderer
	{
		/// <summary>
		/// Gets the application.
		/// </summary>
		/// <value>The application.</value>
		UIApplication Application {
			get {
				return UIApplication.SharedApplication;
			}
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			if (NavigationController == null)
				return;

			Application.StatusBarStyle = UIStatusBarStyle.Default;


			var itemsInfo = (Element as ContentPage).ToolbarItems;

			var navigationItem = NavigationController.TopViewController.NavigationItem;
			var leftNativeButtons = (navigationItem.LeftBarButtonItems ?? new UIBarButtonItem[]{ }).ToList();
			var rightNativeButtons = (navigationItem.RightBarButtonItems ?? new UIBarButtonItem[]{ }).ToList();

			rightNativeButtons.ForEach(nativeItem =>
			{
				var info = GetButtonInfo(itemsInfo, nativeItem.Title);

				if (info == null || info.Priority != 0)
				{
					if (info.Priority == 1)
						nativeItem.Style = UIBarButtonItemStyle.Done;

					return;
				}

				rightNativeButtons.Remove(nativeItem);
				leftNativeButtons.Add(nativeItem);
			});

			navigationItem.RightBarButtonItems = rightNativeButtons.ToArray();
			navigationItem.LeftBarButtonItems = leftNativeButtons.ToArray();
		}

		ToolbarItem GetButtonInfo(IList<ToolbarItem> items, string name)
		{
			if (string.IsNullOrEmpty(name) || items == null)
				return null;

			return items.ToList().FirstOrDefault(itemData => name.Equals(itemData.Name));
		}

	}
}

