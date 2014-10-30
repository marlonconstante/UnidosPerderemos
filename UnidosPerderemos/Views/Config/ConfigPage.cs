using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.Config
{
	public class ConfigPage : ContentPage, IControlPage
	{
		public ConfigPage()
		{
			var dateField = new DateField();
			dateField.TextColor = Color.Black;

			var inputGender = new OptionButton();
			inputGender.Items = GenderInfo.GetGenderItems();
			inputGender.SelectedItem = App.CurrentUser.Gender;

			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Configurações")
				{
					new TableSection("Perfil")
					{
						new EntryCell
						{
							Label = "Nome:",
							Text = App.CurrentUserProfile.UserName,
							Keyboard = Keyboard.Default
						},
						new ViewCell
						{
							View = dateField
						},
						new ViewCell
						{
							View = inputGender
						},
						new EntryCell
						{
							Label = "Peso:",
							Text = App.CurrentUserProfile.Weight.ToString(),
							Keyboard = Keyboard.Numeric
						},
						new EntryCell
						{
							Label = "Altura:",
							Text = App.CurrentUserProfile.Height.ToString(),
							Keyboard = Keyboard.Numeric
						}
					},
					new TableSection("Tática")
					{
						new EntryCell
						{
							Label = "Meta de Peso:",
							Text = App.CurrentUserProfile.GoalWeight.ToString(),
							Keyboard = Keyboard.Numeric
						},
						new EntryCell
						{
							Label = "Meta de Tempo:",
							Text = App.CurrentUserProfile.GoalTime.ToString(),
							Keyboard = Keyboard.Numeric
						}
					}
				}
			};
		}

		#region IControlPage implementation

		/// <summary>
		/// Preferreds the status bar style.
		/// </summary>
		/// <returns>The status bar style.</returns>
		public StatusBarStyle PreferredStatusBarStyle()
		{
			return StatusBarStyle.Light;
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

		#endregion
	}
}

