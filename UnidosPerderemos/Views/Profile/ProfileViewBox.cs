using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Services;
using System.IO;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfileViewBox : ContentView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Views.Profile.ProfileViewBox"/> class.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public ProfileViewBox(UserProfile userProfile)
		{
			UserProfile = userProfile;
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
			if (IsCurrentUserProfile)
			{
				AddTappedPhoto();
			}
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
			var stream = await DependencyService.Get<IMediaService>().GetPhoto(new Size(400d, 400d));
			if (stream != Stream.Null)
			{
				Photo.LoadingSource = true;

				UserProfile.Photo.Stream = stream;
				if (await DependencyService.Get<IProfileService>().Save(UserProfile))
				{
					Photo.Source = ImageSource.FromStream(() => {
						return stream;
					});
				}
				else
				{
					Photo.LoadingSource = false;
				}
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
			Aspect = Aspect.AspectFill,
			BackgroundColor = Color.FromHex("af6ac6"),
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
			TextColor = Color.White
		};

		/// <summary>
		/// Gets the label current weight.
		/// </summary>
		/// <value>The label current weight.</value>
		CompressedLabel LabelCurrentWeight {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Medium", 20),
			TextColor = Color.White
		};

		/// <summary>
		/// Gets the linear progress.
		/// </summary>
		/// <value>The linear progress.</value>
		LinearProgressBar LinearProgress {
			get;
		} = new LinearProgressBar {
			Progress = 0
		};

		/// <summary>
		/// Gets the label current day.
		/// </summary>
		/// <value>The label current day.</value>
		CompressedLabel LabelCurrentDay {
			get;
		} = new CompressedLabel {
			Font = Font.OfSize("Roboto-Light", 13),
			TextColor = Color.White,
			XAlign = TextAlignment.End,
			TranslationX = -10d,
			TranslationY = -5d
		};

		/// <summary>
		/// Gets or sets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is current user profile.
		/// </summary>
		/// <value><c>true</c> if this instance is current user profile; otherwise, <c>false</c>.</value>
		bool IsCurrentUserProfile {
			get {
				return UserProfile == App.Instance.CurrentUserProfile;
			}
		}

		/// <summary>
		/// Gets or sets the progress.
		/// </summary>
		/// <value>The progress.</value>
		public int Progress {
			get {
				return LinearProgress.Progress;
			}
			set {
				LinearProgress.Progress = value;
			}
		}

		/// <summary>
		/// Loads the photo.
		/// </summary>
		async void LoadPhoto()
		{
			Photo.LoadingSource = true;

			await DependencyService.Get<IFileService>().Download(UserProfile.Photo);

			Photo.Source = ImageSource.FromStream(() => {
				return UserProfile.Photo.Stream;
			});
		}

		/// <summary>
		/// Updates the information.
		/// </summary>
		public void UpdateInfo()
		{
			LabelInitialWeight.Text = string.Concat("Comecei com ", UserProfile.InitialWeight.ToString(), "kg");
			LabelCurrentWeight.Text = string.Concat("ESTOU COM ", UserProfile.Weight.ToString(), "KG");
			LabelCurrentDay.Text = string.Concat("Atualmente no dia ", UserProfile.ElapsedTime.ToString() ," de ", UserProfile.GoalTime.ToString());

			if (Photo.Source == null)
			{
				LoadPhoto();
			}
		}
	}
}