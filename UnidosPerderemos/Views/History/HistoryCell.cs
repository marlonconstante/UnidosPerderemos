using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.History
{
	public class HistoryCell: ViewCell
	{
		public Label Description
		{
			get;
			set;
		} = new Label()
		{
			YAlign = TextAlignment.Center,
			XAlign = TextAlignment.End
		};

		public Image ContactPhoto
		{
			get;
			set;
		}

		public HistoryCell()
		{
			Description.SetBinding(Label.TextProperty, "Description");
//			ContactPhoto.SetBinding(Image.SourceProperty, "ContactPhoto");

			var grid = new Grid
			{
				Padding = new Thickness(5, 5, 5, 5),
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				},
				Children =
				{
//					{ ContactPhoto, 0, 0 },
					{ Description, 1, 0 }
				}
			};

			View = grid;
			View.BackgroundColor = Color.Transparent;
		}
			
	}
}

