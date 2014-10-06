using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public partial class GoalPage : ContentPage
	{
		public GoalPage()
		{
			InitializeComponent();

			Content = new Image {
				Aspect = Aspect.AspectFill,
				Source = ImageSource.FromFile("BackgroundGoal.png")
			};
		}
	}
}