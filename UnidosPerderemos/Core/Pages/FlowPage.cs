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

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Pages.FlowPage"/> class.
		/// </summary>
		/// <param name="startPage">Start page.</param>
		public FlowPage(Page startPage)
		{
			SetUp();
			PushAsync(startPage);
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