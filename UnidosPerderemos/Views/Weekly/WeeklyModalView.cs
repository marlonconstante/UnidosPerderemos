using System;
using UnidosPerderemos.Core.Controls;
using Xamarin.Forms;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.Weekly
{
	public class WeeklyModalView : ModalView
	{
		public WeeklyModalView()
		{
			Title = "Mais uma semana passou.\nInforme o seu peso atual:";
			TitleFontSize = 20.5d;
			InnerView = InputWeight;

			ConfirmClicked += (object sender, EventArgs args) => {
				UserProfile.Weight = double.Parse(InputWeight.Text);
			};
		}

		/// <summary>
		/// Show this instance.
		/// </summary>
		public override void Show()
		{
			InputWeight.Text = UserProfile.Weight.ToString();

			base.Show();
		}

		/// <summary>
		/// Gets the input weight.
		/// </summary>
		/// <value>The input weight.</value>
		UnderlineTextField InputWeight {
			get;
		} = new UnderlineTextField {
			Font = Font.OfSize("Roboto-Regular", 46),
			AdditionalFont = Font.OfSize("Roboto-Light", 28),
			AdditionalText = "Quilos",
			AdditionalTranslationY = 1.5d,
			TextColor = Color.FromHex("464646"),
			BottomLineHeight = 0d,
			MaxLength = 4,
			Keyboard = Keyboard.Numeric
		};

		/// <summary>
		/// Gets the user profile.
		/// </summary>
		/// <value>The user profile.</value>
		UserProfile UserProfile {
			get {
				return App.Instance.CurrentUserProfile;
			}
		}
	}
}