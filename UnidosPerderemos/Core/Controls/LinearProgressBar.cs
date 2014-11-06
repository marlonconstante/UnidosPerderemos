using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class LinearProgressBar : StackLayout
	{
		public LinearProgressBar()
		{
			Padding = new Thickness(0f, 9f, 0f, 9f);
			Children.Add(
				new Image
				{
					Source = ImageSource.FromFile("Progress30.png"),
					Aspect = Aspect.AspectFill
				}
			);
		}
	}
}

