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
		public ProfileViewGraphics()
		{
			SetUp();

			Content = new StackLayout {
				Spacing = 2.5d,
				Children = {
					LabelTitle,
					new Grid {
						ColumnDefinitions = {
							new ColumnDefinition {
								Width = new GridLength(1d, GridUnitType.Star)
							}
						},
						Children = {
							RadialProgress,
							GridProgress
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
			Progress = 0;
		}

		/// <summary>
		/// Updates the labels.
		/// </summary>
		void UpdateLabels()
		{
			var progress = Progress.ToString();
			LabelProgress.Text = progress;

			var fontSize = 44 - ((progress.Length - 1) * 9);
			LabelProgress.FontSize = fontSize;
			LabelPercent.FontSize = fontSize / 2;
		}

		/// <summary>
		/// Gets the label title.
		/// </summary>
		/// <value>The label title.</value>
		CompressedLabel LabelTitle {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Regular", 16),
			TextColor = Color.FromHex("f6f7f9"),
			XAlign = TextAlignment.Center
		};

		/// <summary>
		/// Gets the radial progress.
		/// </summary>
		/// <value>The radial progress.</value>
		RadialProgressBar RadialProgress {
			get;
		} = new RadialProgressBar {
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			WidthRequest = 80d,
			HeightRequest = 80d
		};

		/// <summary>
		/// Gets the grid progress.
		/// </summary>
		/// <value>The grid progress.</value>
		Grid GridProgress {
			get {
				return new Grid {
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					ColumnSpacing = 0d,
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = GridLength.Auto
						},
						new ColumnDefinition {
							Width = GridLength.Auto
						}
					},
					Children = {
						{ LabelProgress, 0, 0 },
						{ LabelPercent, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the label progress.
		/// </summary>
		/// <value>The label progress.</value>
		Label LabelProgress {
			get;
		} = new Label {
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			FontFamily = "Roboto-Light",
			TextColor = Color.FromHex("fcfbfb")
		};

		/// <summary>
		/// Gets the label percent.
		/// </summary>
		/// <value>The label percent.</value>
		Label LabelPercent {
			get;
		} = new Label {
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			FontFamily = "Roboto-Light",
			TextColor = Color.FromHex("fcfbfb"),
			Text = "%"
		};

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get {
				return LabelTitle.Text;
			}
			set {
				LabelTitle.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the progress.
		/// </summary>
		/// <value>The progress.</value>
		public int Progress {
			get {
				return RadialProgress.Progress;
			}
			set {
				RadialProgress.Progress = value;

				UpdateLabels();
			}
		}

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public RadialProgressType Type {
			get {
				return RadialProgress.Type;
			}
			set {
				RadialProgress.Type = value;
			}
		}
	}
}