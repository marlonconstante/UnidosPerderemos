using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Models;
using UnidosPerderemos.Services;
using System.Threading.Tasks;
using System;
using UnidosPerderemos.Core.Pages;
using UnidosPerderemos.Core.Styles;
using UnidosPerderemos.Utils;

namespace UnidosPerderemos.Views.Config
{
	public class ConfigPage : ContentPage, IControlPage
	{
		TextField m_name;
		DateField m_dateField;
		OptionButton m_inputGender;
		TextField m_weightInput;
		TextField m_heightInput;
		TextField m_goalWeight;
		TextField m_goalTime;
		Switch m_entryTacticExercise;
		Switch m_entryTacticFeed;
		Button m_btnLogout;

		public ConfigPage()
		{
			ConfigureToolbar();
			SetupInputs();
			CreateLogoutButton();
			CreateContentPage();
		}

		/// <summary>
		/// Logout this instance.
		/// </summary>
		async void Logout()
		{
			await Navigation.PopModalAsync();
			DependencyService.Get<IUserService>().Logout();
			App.Instance.ReloadMainPage();
		}

		/// <summary>
		/// Configures the toolbar.
		/// </summary>
		void ConfigureToolbar()
		{
			Title = "Configurações";

			ToolbarItems.Add(new LeftToolbarItem {
				Name = "Cancelar",
				Command = new Command(() => Navigation.PopModalAsync())
			});
			ToolbarItems.Add(new RightToolbarItem {
				Name = "Salvar",
				Command = new Command(() => Save())
			});
		}

		/// <summary>
		/// Setups the inputs.
		/// </summary>
		void SetupInputs()
		{
			m_dateField = new DateField();
			m_dateField.TextColor = Color.Black;
			m_dateField.Font = Font.OfSize("Roboto-Regular", 16);
			m_dateField.TextAlignment = TextAlignment.End;
			m_dateField.HeightRequest = 22d;
			m_dateField.Date = UserProfile.DateOfBirth;

			m_inputGender = new OptionButton();
			m_inputGender.TintColor = Color.Black;
			m_inputGender.Items = GenderInfo.GetItems();
			m_inputGender.SelectedItem = UserProfile.Gender;

			m_name = new CellTextField(UserProfile.UserName, Keyboard.Text);
			m_weightInput = new CellTextField(UserProfile.Weight.ToString(), Keyboard.Numeric);
			m_heightInput = new CellTextField(UserProfile.Height.ToString(), Keyboard.Numeric);
			m_goalWeight = new CellTextField(UserProfile.GoalWeight.ToString(), Keyboard.Numeric);
			m_goalTime = new CellTextField(UserProfile.GoalTime.ToString(), Keyboard.Numeric);

			m_entryTacticExercise = new Switch {
				IsToggled = UserProfile.IsTacticExercise
			};
			m_entryTacticFeed = new Switch {
				IsToggled = UserProfile.IsTacticFeed
			};
		}

		/// <summary>
		/// Creates the logout button.
		/// </summary>
		void CreateLogoutButton()
		{
			m_btnLogout = new Button {
				Text = "Sair",
				TextColor = Color.Red,
				Font = Font.OfSize("Roboto-Regular", 16),
				BackgroundColor = Color.Transparent
			};
			m_btnLogout.Clicked += (sender, e) => Logout();
		}

		/// <summary>
		/// Creates the tabble view root.
		/// </summary>
		/// <returns>The tabble view root.</returns>
		TableRoot CreateTabbleViewRoot()
		{
			return new TableRoot("Configurações") {
				new TableSection("Perfil") {
					new EntryViewCell("Nome:", m_name),
					new EntryViewCell("Nascimento:", m_dateField),
					new EntryViewCell("Sexo:", m_inputGender),
					new EntryViewCell("Peso:", m_weightInput),
					new EntryViewCell("Altura:", m_heightInput),
				},
				new TableSection("Metas") {
					new EntryViewCell("Quantos quilos deseja perder?", m_goalWeight),
					new EntryViewCell("Em quantos dias?", m_goalTime),
				},
				new TableSection("Táticas") {
					new EntryViewCell("Fazer exercícios:", m_entryTacticExercise),
					new EntryViewCell("Cuidar da alimentação:", m_entryTacticFeed)
				},
				new TableSection("") {
					new ViewCell {
						View = m_btnLogout
					}
				}
			};
		}

		/// <summary>
		/// Creates the content page.
		/// </summary>
		void CreateContentPage()
		{
			Content = new TableView {
				Intent = TableIntent.Form,
				Root = CreateTabbleViewRoot()
			};
		}

		/// <summary>
		/// Save this instance.
		/// </summary>
		async void Save()
		{
			UserProfile.DateOfBirth = m_dateField.Date;
			UserProfile.Gender = (Gender) m_inputGender.SelectedItem;
			UserProfile.UserName = m_name.Text;
			UserProfile.Weight = m_weightInput.Text.ParseDouble();
			UserProfile.Height = m_heightInput.Text.ParseDouble();
			UserProfile.GoalWeight = m_goalWeight.Text.ParseDouble();
			UserProfile.GoalTime = m_goalTime.Text.ParseDouble();
			UserProfile.IsTacticExercise = m_entryTacticExercise.IsToggled;
			UserProfile.IsTacticFeed = m_entryTacticFeed.IsToggled;

			if (await DependencyService.Get<IProfileService>().Save(UserProfile))
			{
				await DisplayAlert("Pronto!", "Configurações atualizadas com sucesso.", "OK");
				await Navigation.PopModalAsync();
			}
			else
			{
				await DisplayAlert("Ops...", "Ocorreu uma falha na conexão com o servidor.", "OK");
			}
		}

		/// <summary>
		/// Gets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get {
				return App.Instance.CurrentUserProfile;
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

		/// <summary>
		/// Backgrounds the name of the image.
		/// </summary>
		/// <returns>The image name.</returns>
		public string BackgroundImageName()
		{
			return null;
		}
	}
}