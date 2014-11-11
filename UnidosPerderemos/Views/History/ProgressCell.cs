using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.History
{
	public class ProgressCell: ViewCell
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

		Grid m_grid;

		public ProgressCell()
		{
//			if ((BindingContext as Progress).Type == ProgressType.Daily)
//			{
				DescriptionLabel.SetBinding(Label.TextProperty, "Comments");
				Photo.SetBinding(Image.SourceProperty, "Photo");

				m_grid = new Grid
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
//			}
//			else
//			{
//				m_grid = new Grid
//				{
//					Padding = new Thickness(5, 5, 5, 5),
//					ColumnDefinitions =
//					{
//						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
//					},
//					Children =
//					{
//						new Label { Text = "Semanal" }
//					}
//				};
//			}

			View = m_grid;
			View.BackgroundColor = Color.Transparent;
		}
			
	}
}

