using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using UnidosPerderemos.Views.Friend;
using MonoTouch.FacebookConnect;
using System.Drawing;

[assembly: ExportRenderer(typeof(FriendCell), typeof(UnidosPerderemos.iOS.Renderers.Controls.FriendCellRenderer))]
namespace UnidosPerderemos.iOS.Renderers.Controls
{
	public class FriendCellRenderer : TextCellRenderer
	{
		public FriendCellRenderer()
		{
		}

		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="item">Item.</param>
		/// <param name="tableView">Table view.</param>
		public override UITableViewCell GetCell(Cell item, UITableView tableView)
		{
			var source = item as FriendCell;
			var target = base.GetCell(source, tableView);

			if (!IsLoadedCell(target))
			{
				var height = (float) source.RenderHeight;
				var padding = 8f;

				tableView.SeparatorInset = new UIEdgeInsets(0f, height + padding, 0f, 0f);
				tableView.SeparatorColor = UIColor.White.ColorWithAlpha(0.6f);

				target.SelectedBackgroundView = new UIView {
					BackgroundColor = UIColor.White.ColorWithAlpha(0.2f)
				};

				target.TextLabel.Font = source.Font.ToUIFont();
				target.DetailTextLabel.Font = source.Font.ToUIFont();

				target.Add(GetProfileView(source.IdFriend, new RectangleF(padding, padding, height - padding, height - padding)));
			}

			return target;
		}

		/// <summary>
		/// Gets the profile view.
		/// </summary>
		/// <returns>The profile view.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="frame">Frame.</param>
		FBProfilePictureView GetProfileView(string id, RectangleF frame) {
			return new FBProfilePictureView(id, FBProfilePictureCropping.Square) {
				Frame = frame,
				BackgroundColor = UIColor.White
			};
		}

		/// <summary>
		/// Determines whether this instance is loaded cell the specified cell.
		/// </summary>
		/// <returns><c>true</c> if this instance is loaded cell the specified cell; otherwise, <c>false</c>.</returns>
		/// <param name="cell">Cell.</param>
		bool IsLoadedCell(UITableViewCell cell) {
			return cell.Subviews.Length > 1;
		}
	}
}