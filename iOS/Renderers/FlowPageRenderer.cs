using System;
using UnidosPerderemos;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;

[assembly: ExportRenderer(typeof(FlowPage), typeof(UnidosPerderemos.iOS.FlowPageRenderer))]
namespace UnidosPerderemos.iOS
{
	public class FlowPageRenderer : NavigationRenderer
	{
		public FlowPageRenderer()
		{
		}

		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Target.TitleTextAttributes = TextAttributes;
		}

		/// <summary>
		/// Gets the text attributes.
		/// </summary>
		/// <value>The text attributes.</value>
		public UIStringAttributes TextAttributes {
			get {
				return new UIStringAttributes {
					Font = Source.Font.ToUIFont(),
					ForegroundColor = Source.BarTextColor.ToUIColor()
				};
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		FlowPage Source {
			get {
				return Element as FlowPage;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UINavigationBar Target {
			get {
				return NavigationBar;
			}
		}
	}
}