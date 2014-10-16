using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfileViewGraphics : ContentView
	{
		public ProfileViewGraphics()
		{
			SetUp();

			RadialProgress.Progress = new Random().Next(0,100);

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
							RadialProgress
						}
					}
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Percentual";
			Percentage = 0;
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
			Font = Font.OfSize("Roboto-Light", 35),
			TextColor = Color.FromHex("fcfbfb"),
			XAlign = TextAlignment.Center
		};

		/// <summary>
		/// Gets the label percent.
		/// </summary>
		/// <value>The label percent.</value>
		CompressedLabel LabelPercent
		{
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Light", 18),
			TextColor = Color.FromHex("fcfbfb"),
			Text = "%",
			TranslationY = 15d,
			XAlign = TextAlignment.Center
		};

		RadialProgressBar RadialProgress
		{
			get;
		} = new RadialProgressBar {
			WidthRequest = 50d,
			HeightRequest = 50d,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			ProgressColor = Color.Aqua,
			Progress = 0
		};

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