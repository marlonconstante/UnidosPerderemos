using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class CellTextField : TextField
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.CellTextField"/> class.
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="keyboard">Keyboard.</param>
		public CellTextField(string text, Keyboard keyboard)
		{
			Text = text;
			Keyboard = keyboard;

			TextColor = Color.Black;
			TextAlignment = TextAlignment.End;
			Font = Font.OfSize("Roboto-Regular", 16);

			HeightRequest = 40d;
			WidthRequest = 250d;
		}
	}
}