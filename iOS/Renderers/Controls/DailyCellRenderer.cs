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
				target.SeparatorInset = UIEdgeInsets.Zero;
				tableView.LayoutMargins = UIEdgeInsets.Zero;
				tableView.SeparatorColor = UIColor.White.ColorWithAlpha(0.6f);

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
			return cell.SeparatorInset.Equals(UIEdgeInsets.Zero);
		}
	}
}