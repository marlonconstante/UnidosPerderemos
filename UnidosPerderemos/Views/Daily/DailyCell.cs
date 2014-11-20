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

			View = new StackLayout {
				Spacing = 3d,
				Padding = new Thickness(10d, 10d, 0d, 0d),
				Children = {
					LabelDate,
					ImagePhoto,
					LabelDescription
				}
			};
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			LoadPhoto();

			Height = PreferredHeight;
		}

		/// <summary>
		/// Loads the photo.
		/// </summary>
		async void LoadPhoto()
		{
			if (Photo.IsValidUrl)
			{
				ImagePhoto.IsVisible = true;

				await DependencyService.Get<IFileService>().Download(Photo);

				ImagePhoto.Source = ImageSource.FromStream(() => {
					return Photo.Stream;
				});
			}
		}

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
		/// Gets the image photo.
		/// </summary>
		/// <value>The image photo.</value>
		Image ImagePhoto {
			get;
		} = new Image {
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Start,
			Aspect = Aspect.AspectFill,
			BackgroundColor = Color.White,
			WidthRequest = 300d,
			HeightRequest = 169d,
			IsVisible = false
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
				var height = 44d;
				height += DependencyService.Get<ITextService>().PreferredSize(LabelDescription.Text, LabelDescription.Font, MaxDescriptionSize).Height;
				if (ImagePhoto.IsVisible)
				{
					height += 3d + ImagePhoto.HeightRequest;
				}
				return height;
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