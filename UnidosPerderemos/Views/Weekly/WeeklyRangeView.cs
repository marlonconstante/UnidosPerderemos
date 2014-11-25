using System;
using Xamarin.Forms;
using UnidosPerderemos.Utils;

namespace UnidosPerderemos.Views.Weekly
{
	public class WeeklyRangeView : ContentView
	{
		public WeeklyRangeView()
		{
			Content = GridRange;

			ButtonComeBack.Clicked += (object sender, EventArgs args) => {
				UpdateInfo(-1);
			};
			ButtonGoForward.Clicked += (object sender, EventArgs args) => {
				UpdateInfo(1);
			};
			UpdateInfo();
		}

		/// <summary>
		/// Updates the info.
		/// </summary>
		/// <param name="additionalWeeks">Additional weeks.</param>
		void UpdateInfo(int additionalWeeks = 0)
		{
			CurrentStartOfWeek = CurrentStartOfWeek.AddDays(additionalWeeks * 7d);
			LabelRange.Text = string.Concat(CurrentStartOfWeek.ToString("dd/MM/yyyy"), " à ", CurrentStartOfWeek.AddDays(6d).ToString("dd/MM/yyyy"));
			if (additionalWeeks != 0 && WeekChanged != null)
			{
				WeekChanged.Invoke(this, EventArgs.Empty);
			}
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
		/// Gets or sets the current start of week.
		/// </summary>
		/// <value>The current start of week.</value>
		public DateTime CurrentStartOfWeek {
			get;
			set;
		} = DateTime.Now.Date.StartOfWeek();

		/// <summary>
		/// Occurs when week changed.
		/// </summary>
		public event EventHandler<EventArgs> WeekChanged;
	}
}