using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using System.Diagnostics;

namespace UnidosPerderemos.Views.Profile
{
	public class ProfilePage : ContentPage, IControlPage
	{
		public ProfilePage()
		{
			SetUp();

			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Spacing = 5d,
					Children =
					{
						ProfileViewBox,
						UpButton,
						TransparentSeparator,
						GridGraphics
					}
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Perfil";
			Icon = ImageSource.FromFile("Profile.png") as FileImageSource;
			BackgroundImage = "BackgroundProfile.png";
		}

		/// <summary>
		/// Gets the profile view box.
		/// </summary>
		/// <value>The profile view box.</value>
		ProfileViewBox ProfileViewBox
		{
			get
			{
				return new ProfileViewBox();
			}
		}

		/// <summary>
		/// Gets up button.
		/// </summary>
		/// <value>Up button.</value>
		UpButton UpButton
		{
			get;
			set;
		} = new UpButton();

		/// <summary>
		/// Gets the transparent separator.
		/// </summary>
		/// <value>The transparent separator.</value>
		BoxView TransparentSeparator
		{
			get
			{
				return new BoxView
				{
					BackgroundColor = Color.White.MultiplyAlpha(0.6d),
					HeightRequest = 1d
				};
			}
		}

		/// <summary>
		/// Gets the grid graphics.
		/// </summary>
		/// <value>The grid graphics.</value>
		Grid GridGraphics
		{
			get
			{
				return new Grid
				{
					ColumnDefinitions =
					{
						new ColumnDefinition
						{
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition
						{
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					Children =
					{
						{ DedicationGraphics, 0, 0 },
						{ GoalGraphics, 1, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the dedication graphics.
		/// </summary>
		/// <value>The dedication graphics.</value>
		ProfileViewGraphics DedicationGraphics
		{
			get
			{
				return new ProfileViewGraphics(Color.Red)
				{
					Title = "Dedicação",
					Percentage = 70
				};
			}
		}

		/// <summary>
		/// Gets the goal graphics.
		/// </summary>
		/// <value>The goal graphics.</value>
		ProfileViewGraphics GoalGraphics
		{
			get
			{
				return new ProfileViewGraphics(Color.Blue)
				{
					Title = "Meta",
					Percentage = 100
				};
			}
		}

		/// <summary>
		/// Preferreds the status bar style.
		/// </summary>
		/// <returns>The status bar style.</returns>
		public StatusBarStyle PreferredStatusBarStyle()
		{
			return StatusBarStyle.Dark;
		}

		/// <summary>
		/// Determines whether this instance is show navigation bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show navigation bar; otherwise, <c>false</c>.</returns>
		public bool IsShowNavigationBar()
		{
			return true;
		}

		/// <summary>
		/// Determines whether this instance is show status bar.
		/// </summary>
		/// <returns><c>true</c> if this instance is show status bar; otherwise, <c>false</c>.</returns>
		public bool IsShowStatusBar()
		{
			return true;
		}
	}
}