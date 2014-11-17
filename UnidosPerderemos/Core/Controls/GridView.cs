using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class GridView : Grid
	{
		public GridView()
		{
			ColumnSpacing = 0d;
			Padding = new Thickness(0d);
			ColumnDefinitions = new ColumnDefinitionCollection {
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			};
			RowDefinitions = new RowDefinitionCollection {
				new RowDefinition {
					Height = new GridLength(1d, GridUnitType.Star)
				}
			};
		}
	}
}