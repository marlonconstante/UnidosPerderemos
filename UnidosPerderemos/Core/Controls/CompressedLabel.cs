using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class CompressedLabel : Label
	{
		public CompressedLabel()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			TextColor = Color.FromHex("fafaf5");
		}
	}
}