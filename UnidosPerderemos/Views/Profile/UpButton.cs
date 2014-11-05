using System;
using UnidosPerderemos.Core.Controls;
using Xamarin.Forms;
using UnidosPerderemos.Views.Main;
using UnidosPerderemos.Views.Daily;

namespace UnidosPerderemos.Views.Profile
{
	public class UpButton : ContentView
	{
		/// <summary>
		/// The is star property.
		/// </summary>
		public static readonly BindableProperty IsStarProperty = BindableProperty.Create<UpButton, bool>(p => p.IsStar, false);

		public UpButton()
		{
			SetUp();

			Content = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = new GridLength(1d, GridUnitType.Star)
					}
				},
				Children = {
					Button,
					StarBox
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			IsStar = false;

			Button.Clicked += OnButtonClicked;
		}

		/// <summary>
		/// Raises the button clicked event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new MainFlowPage(new DailyPage()));
		}

		/// <summary>
		/// Gets the button.
		/// </summary>
		/// <value>The button.</value>
		ImageButton Button {
			get;
		} = new ImageButton {
			Image = ImageSource.FromFile("UpButton.png") as FileImageSource,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			WidthRequest = 246d,
			HeightRequest = 215d
		};

		/// <summary>
		/// Gets the star box.
		/// </summary>
		/// <value>The star box.</value>
		StackLayout StarBox {
			get;
		} = new StackLayout {
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			TranslationX = 79d,
			TranslationY = 64d
		};

		/// <summary>
		/// Gets the full star.
		/// </summary>
		/// <value>The full star.</value>
		Image FullStar {
			get;
		} = new Image {
			Source = ImageSource.FromFile("FullStar.png"),
			WidthRequest = 42d,
			HeightRequest = 40d
		};

		/// <summary>
		/// Gets the empty star.
		/// </summary>
		/// <value>The empty star.</value>
		Image EmptyStar {
			get;
		} = new Image {
			Source = ImageSource.FromFile("EmptyStar.png"),
			WidthRequest = 42d,
			HeightRequest = 40d
		};

		/// <summary>
		/// Gets or sets a value indicating whether this instance is star.
		/// </summary>
		/// <value><c>true</c> if this instance is star; otherwise, <c>false</c>.</value>
		public bool IsStar {
			get {
				return (bool) GetValue(IsStarProperty);
			}
			set {
				SetValue(IsStarProperty, value);

				StarBox.Children.Clear();
				StarBox.Children.Add(value ? FullStar : EmptyStar);
			}
		}
	}
}