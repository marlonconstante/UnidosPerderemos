using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Views.Weekly
{
	public class WeeklyRangeView : ContentView
	{
		public WeeklyRangeView()
		{
			Content = GridRange;
		}

		/// <summary>
		/// Gets the button come back.
		/// </summary>
		/// <value>The button come back.</value>
		Button ButtonComeBack {
			get;
		} = new Button {
			Text = "<",
			TextColor = Color.FromHex("f26522"),
			BorderColor = Color.FromHex("f26522"),
			BorderWidth = 1d,
			FontSize = 16d,
			HeightRequest = 29d
		};

		/// <summary>
		/// Gets the label range.
		/// </summary>
		/// <value>The label range.</value>
		Label LabelRange {
			get;
		} = new Label {
			Text = "17/11/2014 à 23/11/2014",
			TextColor = Color.FromHex("f26522"),
			FontFamily = "Roboto-Medium",
			FontSize = 16d,
			XAlign = TextAlignment.Center,
			YAlign = TextAlignment.Center
		};

		/// <summary>
		/// Gets the button go forward.
		/// </summary>
		/// <value>The button go forward.</value>
		Button ButtonGoForward {
			get;
		} = new Button {
			Text = ">",
			TextColor = Color.FromHex("f26522"),
			BorderColor = Color.FromHex("f26522"),
			BorderWidth = 1d,
			FontSize = 16d,
			HeightRequest = 29d
		};

		/// <summary>
		/// Gets the grid range.
		/// </summary>
		/// <value>The grid range.</value>
		Grid GridRange {
			get {
				return new Grid {
					Padding = new Thickness(5d),
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = GridLength.Auto
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = GridLength.Auto
						}
					},
					Children = {
						{ ButtonComeBack, 0, 0 },
						{ LabelRange, 1, 0 },
						{ ButtonGoForward, 2, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Occurs when week changed.
		/// </summary>
		public event EventHandler WeekChanged {
			add {
				ButtonComeBack.Clicked += value;
				ButtonGoForward.Clicked += value;
			}
			remove {
				ButtonComeBack.Clicked -= value;
				ButtonGoForward.Clicked -= value;
			}
		}
	}
}