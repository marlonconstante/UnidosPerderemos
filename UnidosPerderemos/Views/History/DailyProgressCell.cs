using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.History
{
	public class DailyProgressCell: ViewCell
	{
//		public static readonly BindableProperty DescriptionProperty = BindableProperty.Create<DailyProgressCell, string>(p => p.Description, string.Empty);

//		public string Description
//		{
//			get;
//			set;
//		}


		public Label DescriptionLabel
		{
			get;
			set;
		} = new Label()
		{
			YAlign = TextAlignment.Center,
			XAlign = TextAlignment.End
		};

		public Image Photo
		{
			get;
			set;
		} = new Image {
			VerticalOptions = LayoutOptions.Center,
			WidthRequest = 24d
		};

		public DailyProgressCell()
		{
			DescriptionLabel.SetBinding(Label.TextProperty, "Description");
			Photo.SetBinding(Image.SourceProperty, "Photo");

			var grid = new Grid
			{
				Padding = new Thickness(5, 5, 5, 5),
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				},
				Children =
				{
					DescriptionLabel,
					Photo
				}
			};

			View = grid;
			View.BackgroundColor = Color.Transparent;
		}
			
	}
}

