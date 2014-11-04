using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Services;
using System.IO;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfileViewBox : ContentView
	{
		public ProfileViewBox()
		{
			SetUp();

			Content = new StackLayout {
				Spacing = 0d,
				Children = {
					new Grid {
						ColumnDefinitions = {
							new ColumnDefinition {
								Width = new GridLength(1d, GridUnitType.Star)
							}
						},
						Children = {
							BackgroundProfileBox,
							GridProfileBox
						}
					},
					Separator
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			AddTappedPhoto();
		}

		/// <summary>
		/// Adds the tapped photo.
		/// </summary>
		void AddTappedPhoto()
		{
			var gestureRecognizer = new TapGestureRecognizer();
			gestureRecognizer.Tapped += OnTappedPhoto;
			Photo.GestureRecognizers.Add(gestureRecognizer);
		}

		/// <summary>
		/// Raises the tapped photo event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async void OnTappedPhoto(object sender, EventArgs args)
		{
			var stream = await DependencyService.Get<IMediaService>().GetPhoto();
			if (stream != Stream.Null)
			{
				Photo.Source = ImageSource.FromStream(() => {
					return stream;
				});
			}
		}

		/// <summary>
		/// Gets the background profile box.
		/// </summary>
		/// <value>The background profile box.</value>
		Image BackgroundProfileBox {
			get {
				return new Image {
					Source = ImageSource.FromFile("BackgroundProfileBox.png"),
					Aspect = Aspect.AspectFill
				};
			}
		}

		/// <summary>
		/// Gets the grid profile box.
		/// </summary>
		/// <value>The grid profile box.</value>
		Grid GridProfileBox {
			get {
				return new Grid {
					ColumnSpacing = 0d,
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = 110d
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					RowDefinitions = {
						new RowDefinition {
							Height = new GridLength(1d, GridUnitType.Star)
						}
					},
					Children = {
						{ PhotoBox, 0, 0 },
						{ InfoBox, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the separator.
		/// </summary>
		/// <value>The separator.</value>
		BoxView Separator {
			get {
				return new BoxView {
					BackgroundColor = Color.FromHex("fcff00"),
					HeightRequest = 2d
				};
			}
		}

		/// <summary>
		/// Gets the photo.
		/// </summary>
		/// <value>The photo.</value>
		RoundImage Photo {
			get;
		} = new RoundImage {
			Source = ImageSource.FromFile("BackgroundProfileBox.png"),
			Aspect = Aspect.AspectFill,
			WidthRequest = 100d,
			HeightRequest = 100d
		};

		/// <summary>
		/// Gets the photo box.
		/// </summary>
		/// <value>The photo box.</value>
		StackLayout PhotoBox {
			get {
				return new StackLayout {
					Padding = 5d,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Children = {
						Photo
					}
				};
			}
		}

		/// <summary>
		/// Gets the info box.
		/// </summary>
		/// <value>The info box.</value>
		StackLayout InfoBox {
			get {
				return new StackLayout {
					Spacing = 0d,
					Padding = new Thickness(5f, 5f, 0f, 0f),
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Children = {
						LabelInitialWeight,
						LabelCurrentWeight,
						LinearProgress,
						LabelCurrentDay
					}
				};
			}
		}

		/// <summary>
		/// Gets the label initial weight.
		/// </summary>
		/// <value>The label initial weight.</value>
		CompressedLabel LabelInitialWeight {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Regular", 16),
			TextColor = Color.White,
			Text = "Comecei com 120kg"
		};

		/// <summary>
		/// Gets the label current weight.
		/// </summary>
		/// <value>The label current weight.</value>
		CompressedLabel LabelCurrentWeight {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Medium", 20),
			TextColor = Color.White,
			Text = "ESTOU COM 120KG"
		};

		/// <summary>
		/// Gets the linear progress.
		/// </summary>
		/// <value>The linear progress.</value>
		StackLayout LinearProgress {
			get {
				return new StackLayout {
					Padding = new Thickness(0f, 9f, 0f, 9f),
					Children = {
						new Image {
							Source = ImageSource.FromFile("EmptyLinearProgress.png"),
							Aspect = Aspect.AspectFill
						}
					}
				};
			}
		}

		/// <summary>
		/// Gets the label current day.
		/// </summary>
		/// <value>The label current day.</value>
		CompressedLabel LabelCurrentDay {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Light", 13),
			TextColor = Color.White,
			Text = "Atualmente no dia 60 de 100",
			TranslationX = 30d
		};
	}
}