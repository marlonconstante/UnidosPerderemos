using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.Daily
{
	public class DailyCell : ViewCell
	{
		/// <summary>
		/// The type property.
		/// </summary>
		public static readonly BindableProperty TypeProperty = BindableProperty.Create<DailyCell, ProgressType>(p => p.Type, ProgressType.Daily);

		/// <summary>
		/// The photo property.
		/// </summary>
		public static readonly BindableProperty PhotoProperty = BindableProperty.Create<DailyCell, RemoteFile>(p => p.Photo, null);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Views.Daily.DailyCell"/> class.
		/// </summary>
		public DailyCell()
		{
			this.SetBinding(TypeProperty, "Type");
			this.SetBinding(PhotoProperty, "Photo");

			LabelDate.SetBinding(Label.TextProperty, "FormattedDate");
			LabelDescription.SetBinding(Label.TextProperty, "Comments");

			InfoLayout.Children.Add(LabelDate);
			InfoLayout.Children.Add(LabelDescription);
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (Type == ProgressType.Daily)
			{
				GridDaily.Children.Add(ImagePhoto, 0, 0);
				GridDaily.Children.Add(InfoLayout, 1, 0);
				View = GridDaily;

				LoadPhoto();
			}
			else
			{
				GridWeekly.Children.Add(InfoLayout, 0, 0);
				View = GridWeekly;
			}

			Height = PreferredHeight;
		}

		/// <summary>
		/// Loads the photo.
		/// </summary>
		async void LoadPhoto()
		{
			if (Photo != null)
			{
				await DependencyService.Get<IFileService>().Download(Photo);

				ImagePhoto.Source = ImageSource.FromStream(() => {
					return Photo.Stream;
				});
			}
		}

		/// <summary>
		/// Gets the grid daily.
		/// </summary>
		/// <value>The grid daily.</value>
		Grid GridDaily {
			get;
		} = new Grid {
			ColumnSpacing = 0d,
			Padding = new Thickness(0d, 10d, 0d, 0d),
			ColumnDefinitions = {
				new ColumnDefinition {
					Width = 64d
				},
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			},
			RowDefinitions = {
				new RowDefinition {
					Height = new GridLength(1d, GridUnitType.Star)
				}
			}
		};

		/// <summary>
		/// Gets the grid weekly.
		/// </summary>
		/// <value>The grid weekly.</value>
		Grid GridWeekly {
			get;
		} = new Grid {
			ColumnSpacing = 0d,
			Padding = new Thickness(10d, 10d, 0d, 0d),
			ColumnDefinitions = {
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			},
			RowDefinitions = {
				new RowDefinition {
					Height = new GridLength(1d, GridUnitType.Star)
				}
			}
		};

		/// <summary>
		/// Gets the image photo.
		/// </summary>
		/// <value>The image photo.</value>
		Image ImagePhoto {
			get;
		} = new Image {
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Start,
			Aspect = Aspect.AspectFill,
			BackgroundColor = Color.White,
			WidthRequest = 44d,
			HeightRequest = 44d
		};

		/// <summary>
		/// Gets the info layout.
		/// </summary>
		/// <value>The info layout.</value>
		StackLayout InfoLayout {
			get;
		} = new StackLayout {
			Spacing = 0d
		};

		/// <summary>
		/// Gets the label date.
		/// </summary>
		/// <value>The label date.</value>
		Label LabelDate {
			get;
		} = new Label {
			Font = Font.OfSize("Roboto-Bold", 17),
			TextColor = Color.FromHex("f26522")
		};

		/// <summary>
		/// Gets the label description.
		/// </summary>
		/// <value>The label description.</value>
		Label LabelDescription {
			get;
		} = new Label {
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
			Font = Font.OfSize("Roboto-Light", 17),
			TextColor = Color.FromHex("464646"),
			WidthRequest = 236d
		};

		/// <summary>
		/// Gets the size of the max description.
		/// </summary>
		/// <value>The size of the max description.</value>
		Size MaxDescriptionSize {
			get {
				return new Size(LabelDescription.WidthRequest, 999d);
			}
		}

		/// <summary>
		/// Gets the height of the preferred.
		/// </summary>
		/// <value>The height of the preferred.</value>
		double PreferredHeight {
			get {
				var size = DependencyService.Get<ITextService>().PreferredSize(LabelDescription.Text, LabelDescription.Font, MaxDescriptionSize);
				return 44d + size.Height;
			}
		}

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public ProgressType Type {
			get {
				return (ProgressType) GetValue(TypeProperty);
			}
			set {
				SetValue(TypeProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		public RemoteFile Photo {
			get {
				return (RemoteFile) GetValue(PhotoProperty);
			}
			set {
				SetValue(PhotoProperty, value);
			}
		}
	}
}