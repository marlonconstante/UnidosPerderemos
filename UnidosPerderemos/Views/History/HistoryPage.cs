﻿using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Models;
using UnidosPerderemos.Services;
using System.Collections.Generic;

namespace UnidosPerderemos.Views.History
{
	public class HistoryPage : ContentPage, IControlPage, ISecurePage
	{
		public HistoryPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Title = "Histórico";
			ListView.BackgroundColor = Color.Transparent;
			Icon = ImageSource.FromFile("History.png") as FileImageSource;

			Content = new ActivityIndicator {
				Color = Color.White,
				IsRunning = true
			};
		}

		/// <summary>
		/// Sets the content page.
		/// </summary>
		void SetContentPage()
		{
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
					ListView
				}
			};
		}

		/// <summary>
		/// Raises the user profile loaded event.
		/// </summary>
		/// <param name="userProfile">User profile.</param>
		public void OnUserProfileLoaded(UserProfile userProfile)
		{
			SetContentPage();

			LoadList(App.Instance.CurrentUser);
		}

		/// <summary>
		/// Loads the list.
		/// </summary>
		/// <param name="user">User.</param>
		async void LoadList(User user)
		{
			ListView.ItemsSource = await DependencyService.Get<IProgressService>().FindAll(user);
		}

		/// <summary>
		/// Gets or sets the list view.
		/// </summary>
		/// <value>The list view.</value>
		ListView ListView {
			get;
		} = new ListView {
			ItemTemplate = new DataTemplate(typeof(ProgressCell))
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

		/// <summary>
		/// Backgrounds the name of the image.
		/// </summary>
		/// <returns>The image name.</returns>
		public string BackgroundImageName()
		{
			return "Background-4.jpg";
		}
	}
}