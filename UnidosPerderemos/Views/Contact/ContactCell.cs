using System;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public class ContactCell : ViewCell
	{
		public ContactCell()
		{
			View = LabelName;
		}

		/// <summary>
		/// Gets the name of the label.
		/// </summary>
		/// <value>The name of the label.</value>
		public Label LabelName {
			get {
				var label = new Label();
				label.SetBinding(Label.TextProperty, "Name");

				return label;
			}
		}
	}
}