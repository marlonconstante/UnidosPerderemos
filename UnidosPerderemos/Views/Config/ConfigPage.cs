using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Models;
using UnidosPerderemos.Views.Main;

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
			inputGender.SelectedItem = App.Instance.CurrentUser.Gender;

			var btnLogout = new GhostButton
			{
				Text = "Logout",
				TextColor = Color.Red,
				BorderColor = Color.Red
			};
			btnLogout.Clicked += (sender, e) => ((MainFlowPage)Navigation).Logout();

			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Configurações")
				{
					new TableSection("Perfil")
					{
//						new ViewCell
//						{
//							View = new RoundImage
//							{
//								Source = ImageSource.FromFile("BackgroundGoal.png"),
//								Aspect = Aspect.AspectFill,
//								WidthRequest = 100d,
//								HeightRequest = 100d
//							},
//							Height = 100d
//						},
						new EntryCell
						{
							Label = "Nome:",
							Text = App.Instance.CurrentUserProfile.UserName,
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
							Text = App.Instance.CurrentUserProfile.Weight.ToString(),
							Keyboard = Keyboard.Numeric
						},
						new EntryCell
						{
							Label = "Altura:",
							Text = App.Instance.CurrentUserProfile.Height.ToString(),
							Keyboard = Keyboard.Numeric
						}
					},
					new TableSection("Metas")
					{
						new EntryCell
						{
							Label = "Meta de Peso:",
							Text = App.Instance.CurrentUserProfile.GoalWeight.ToString(),
							Keyboard = Keyboard.Numeric
						},
						new EntryCell
						{
							Label = "Meta de Tempo:",
							Text = App.Instance.CurrentUserProfile.GoalTime.ToString(),
							Keyboard = Keyboard.Numeric
						}
					},
					new TableSection("Táticas")
					{
						new SwitchCell
						{
							Text = "Fazer Exercícios:",
							On = App.Instance.CurrentUserProfile.IsTacticExercise
						},
						new SwitchCell
						{
							Text = "Comer Melhor:",
							On = App.Instance.CurrentUserProfile.IsTacticFeed
						}
					},

					new TableSection("Táticas")
					{
						new ViewCell
						{
							View = btnLogout
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

