using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class LHEntryCell: ViewCell
	{
		public Font Font
		{
			get { return m_font; }
			set { m_font = value; }
		}

		Font m_font = Font.OfSize("Roboto-Regular", 16);

		public LHEntryCell(string label, View entry)
		{
			entry.HorizontalOptions = LayoutOptions.End;
			entry.VerticalOptions = LayoutOptions.Center;

			View = new Grid
			{
				ColumnDefinitions =
				{
					new ColumnDefinition
					{
						Width = new GridLength(0.55d, GridUnitType.Star)
					},
					new ColumnDefinition
					{
						Width = new GridLength(1d, GridUnitType.Star),
					}
				},
				Children =
				{

					{ new Label { Text = label, Font = m_font }, 0, 0 },
					{ entry, 1, 0 }
				},
				Padding = new Thickness(15f, 5f, 5f, 0f)
			};
		}
	}
}

