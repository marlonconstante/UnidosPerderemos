using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using UnidosPerderemos.Core.Controls;
using Xamarin.Forms;
using System.Linq;
using System.Collections;

[assembly: ExportRenderer(typeof(OptionButton), typeof(UnidosPerderemos.iOS.Renderers.Controls.OptionButtonRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class OptionButtonRenderer : ViewRenderer<OptionButton, UISegmentedControl>
	{
		public OptionButtonRenderer()
		{
		}

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<OptionButton> args)
		{
			base.OnElementChanged(args);

			SetNativeControl(new UISegmentedControl {
				TintColor = UIColor.FromRGB(252, 255, 0)
			});

			foreach (var item in Source.Items.Keys)
			{
				Target.InsertSegment(item, Target.NumberOfSegments, false);
			}

			Target.SelectedSegment = Math.Max(Items.IndexOf(Source.SelectedItem), 0);
			Target.ValueChanged += SelectSegment;
			SelectSegment(Target, EventArgs.Empty);
		}

		/// <summary>
		/// Selects the segment.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void SelectSegment(object sender, EventArgs args)
		{
			Source.SelectedItem = Items[Target.SelectedSegment];
		}

		/// <summary>
		/// Dispose the specified disposing.
		/// </summary>
		/// <param name="disposing">If set to <c>true</c> disposing.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Target.ValueChanged -= SelectSegment;
			}

			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <value>The items.</value>
		IList Items {
			get {
				return Source.Items.Values.ToList();
			}
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		/// <value>The source.</value>
		OptionButton Source {
			get {
				return Element as OptionButton;
			}
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		UISegmentedControl Target {
			get {
				return Control;
			}
		}
	}
}