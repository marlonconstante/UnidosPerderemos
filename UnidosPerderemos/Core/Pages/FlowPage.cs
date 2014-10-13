using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Pages
{
	public class FlowPage : NavigationPage
	{
		/// <summary>
		/// The font property.
		/// </summary>
		public static readonly BindableProperty FontProperty = BindableProperty.Create<FlowPage, Font>(p => p.Font, Font.Default);

		public FlowPage()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			BarBackgroundColor = Color.FromHex("f8f8f8");
			BarTextColor = Color.FromHex("ee5555");
			Font = Font.OfSize("TisaSansPro-BoldItalic", 18);
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get {
				return (Font) GetValue(FontProperty);
			}
			set {
				SetValue(FontProperty, value);
			}
		}
	}
}