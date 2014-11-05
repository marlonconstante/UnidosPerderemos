using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using System.Diagnostics;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfileViewGraphics : ContentView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Views.Profile.ProfileViewGraphics"/> class.
		/// </summary>
		/// <param name="percent">Percent.</param>
		/// <param name="progressType">Progress type.</param>
		public ProfileViewGraphics(int percent, string progressType)
		{
			SetUp(percent, progressType);

			Content = new StackLayout
			{
				Children =
				{
					LabelTitle,
					new Grid
					{
						ColumnDefinitions =
						{
							new ColumnDefinition
							{
								Width = new GridLength(1d, GridUnitType.Star)
							}
						},
						Children =
						{
							LabelPercentage,
							LabelPercent,
							RadialProgress
						}
					}
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		/// <param name="percent">Percent.</param>
		/// <param name="progressType">Progress type.</param>
		void SetUp(int percent, string progressType)
		{
			Title = "Percentual";
			Percentage = percent;

			RadialProgress = new RadialProgressBar
			{
				WidthRequest = 80d,
				HeightRequest = 80d,
				Progress = percent,
				ProgressType = progressType,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

		}

		/// <summary>
		/// Gets the label title.
		/// </summary>
		/// <value>The label title.</value>
		CompressedLabel LabelTitle
		{
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Regular", 16),
			TextColor = Color.FromHex("f6f7f9"),
			XAlign = TextAlignment.Center
		};

		/// <summary>
		/// Gets the label percentage.
		/// </summary>
		/// <value>The label percentage.</value>
		CompressedLabel LabelPercentage
		{
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Light", 28),
			TextColor = Color.FromHex("fcfbfb"),
			XAlign = TextAlignment.Center,
			YAlign = TextAlignment.Center,
			HeightRequest = 80d,
			TranslationX = -5d
		};

		/// <summary>
		/// Gets the label percent.
		/// </summary>
		/// <value>The label percent.</value>
		CompressedLabel LabelPercent
		{
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Light", 14),
			TextColor = Color.FromHex("fcfbfb"),
			Text = "%",
			XAlign = TextAlignment.Center,
			YAlign = TextAlignment.Center,
			TranslationY = 5d,
			TranslationX = -25d,
			HeightRequest = 80d
		};

		RadialProgressBar RadialProgress
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title
		{
			get
			{
				return LabelTitle.Text;
			}
			set
			{
				LabelTitle.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the percentage.
		/// </summary>
		/// <value>The percentage.</value>
		public int Percentage
		{
			get
			{
				return int.Parse(LabelPercentage.Text);
			}
			set
			{
				LabelPercentage.Text = value.ToString();

				LabelPercent.TranslationX = 6d + (LabelPercentage.Text.Length * 10d);
			}
		}
	}
}