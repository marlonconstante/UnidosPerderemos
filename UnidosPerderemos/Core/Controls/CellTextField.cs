using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class CellTextField : TextField
	{
		public CellTextField(string text)
		{
			Text = text;
			TextColor = Color.Black;
			Font = Font.OfSize("Roboto-Regular", 16);
			HeightRequest = 20d;
		}
	}
}

