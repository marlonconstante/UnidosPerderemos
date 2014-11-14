using System;
using UnidosPerderemos;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;

[assembly: ExportRenderer(typeof(FlowPage), typeof(UnidosPerderemos.iOS.Renderers.Pages.FlowPageRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Pages
{
	public class FlowPageRenderer : NavigationRenderer
	{
		public FlowPageRenderer()
		{
		}

		/// <summary>
		/// Views the will appear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

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