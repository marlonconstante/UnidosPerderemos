﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.Friend
{
	public class FriendPage : ContentPage, IControlPage
	{
		public FriendPage()
		{
			SetUp();

			Content = new Grid {
				ColumnDefinitions = {
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
					BackgroundGradient,
					ListView
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Amigos";
			Icon = ImageSource.FromFile("Contact.png") as FileImageSource;
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			LoadFriends();
		}

		/// <summary>
		/// Loads the friends.
		/// </summary>
		async void LoadFriends()
		{
			ListView.ItemsSource = await DependencyService.Get<IFacebookService>().FindAllFriends();
		}

		/// <summary>
		/// Gets the background gradient.
		/// </summary>
		/// <value>The background gradient.</value>
		Image BackgroundGradient {
			get {
				return new Image {
					Source = ImageSource.FromFile("BackgroundGradient.png"),
					Aspect = Aspect.Fill
				};
			}
		}

		/// <summary>
		/// Gets or sets the list view.
		/// </summary>
		/// <value>The list view.</value>
		ListView ListView {
			get;
		} = new ListView {
			ItemTemplate = new DataTemplate(typeof(FriendCell)),
			BackgroundColor = Color.Transparent,
			RowHeight = 52
		};

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