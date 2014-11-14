using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.History
{
	public class ProgressCell: ViewCell
	{
		public static readonly BindableProperty ProgressTypeProperty = BindableProperty.Create<ProgressCell, ProgressType>(p => p.Type, ProgressType.Daily);

		public ProgressType Type {
			get {
				return (ProgressType) GetValue(ProgressTypeProperty);
			}
			set {
				SetValue(ProgressTypeProperty, value);
			}
		}

		public Label DescriptionLabel {
			get;
			set;
		} = new Label
		{
			YAlign = TextAlignment.Center,
			XAlign = TextAlignment.End
		};

		public Image Photo {
			get;
			set;
		} = new Image {
			VerticalOptions = LayoutOptions.Center,
			WidthRequest = 24d
		};

		Grid m_grid;

		public ProgressCell()
		{
			this.SetBinding(ProgressTypeProperty, "Type");

			if (Type == ProgressType.Daily)
			{
				DescriptionLabel.SetBinding(Label.TextProperty, "Comments");
				Photo.SetBinding(Image.SourceProperty, "Photo");

				m_grid = new Grid {
					Padding = new Thickness(5, 5, 5, 5),
					ColumnDefinitions = {
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					},
					Children = {
						DescriptionLabel,
						Photo
					}
				};
			}
			else
			{
				m_grid = new Grid {
					Padding = new Thickness(5, 5, 5, 5),
					ColumnDefinitions = {
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					},
					Children = {
						new Label { Text = "Semanal" }
					}
				};
			}

			View = m_grid;
			View.BackgroundColor = Color.Transparent;
		}
	}
}