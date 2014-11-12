using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class CellTextField : TextField
	{
		public CellTextField(string text, Keyboard keyboard)
		{
			Text = text;
			Keyboard = keyboard;

			TextColor = Color.Black;
			TextAlignment = TextAlignment.End;
			Font = Font.OfSize("Roboto-Regular", 16);

			WidthRequest = 250d;
		}
	}
}