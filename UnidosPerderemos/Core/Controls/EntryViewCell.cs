using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class EntryViewCell : ViewCell
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.EntryViewCell"/> class.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="entry">Entry.</param>
		public EntryViewCell(string title, View entry)
		{
			entry.HorizontalOptions = LayoutOptions.End;
			entry.VerticalOptions = LayoutOptions.Center;

			View = new Grid {
				Padding = new Thickness(15f, 0f, 10f, 0f),
				ColumnSpacing = 5f,
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = GridLength.Auto
					},
					new ColumnDefinition {
						Width = new GridLength(1d, GridUnitType.Star)
					}
				},
				RowDefinitions = {
					new RowDefinition {
						Height = new GridLength(1d, GridUnitType.Star)
					}
				},
				Children = {
					{ new Label { Text = title, Font = Font, YAlign = TextAlignment.Center }, 0, 0 },
					{ entry, 1, 0 }
				}
			};
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get;
			set;
		} = Font.OfSize("Roboto-Regular", 16);
	}
}