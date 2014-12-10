using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UnidosPerderemos.Views.Daily;
using MonoTouch.UIKit;
using System.Drawing;

[assembly: ExportRenderer(typeof(DailyCell), typeof(UnidosPerderemos.iOS.Renderers.Controls.DailyCellRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class DailyCellRenderer : ViewCellRenderer
	{
		public DailyCellRenderer()
		{
			SeparatorInset = (CurrentVersion.Major >= 8) ? UIEdgeInsets.Zero : new UIEdgeInsets(0f, 10f, 0f, 0f);
		}

		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="item">Item.</param>
		/// <param name="reusableCell">Reusable cell.</param>
		/// <param name="tableView">Table view.</param>
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tableView)
		{
			var source = item as DailyCell;
			var target = base.GetCell(source, reusableCell, tableView);

			if (!IsLoadedCell(target))
			{
				target.SeparatorInset = SeparatorInset;
				tableView.SeparatorColor = UIColor.White.ColorWithAlpha(0.6f);
				if (CurrentVersion.Major >= 8)
				{
					tableView.LayoutMargins = UIEdgeInsets.Zero;
				}

				target.SelectedBackgroundView = new UIView {
					BackgroundColor = UIColor.White.ColorWithAlpha(0.2f)
				};
			}

			return target;
		}

		/// <summary>
		/// Determines whether this instance is loaded cell the specified cell.
		/// </summary>
		/// <returns><c>true</c> if this instance is loaded cell the specified cell; otherwise, <c>false</c>.</returns>
		/// <param name="cell">Cell.</param>
		bool IsLoadedCell(UITableViewCell cell)
		{
			return cell.SeparatorInset.Equals(SeparatorInset);
		}

		/// <summary>
		/// Gets or sets the separator inset.
		/// </summary>
		/// <value>The separator inset.</value>
		UIEdgeInsets SeparatorInset {
			get;
			set;
		}

		/// <summary>
		/// Gets the current version.
		/// </summary>
		/// <value>The current version.</value>
		Version CurrentVersion {
			get {
				return new Version(UIDevice.CurrentDevice.SystemVersion);
			}
		}
	}
}