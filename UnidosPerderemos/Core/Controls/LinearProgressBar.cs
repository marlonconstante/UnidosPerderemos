using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class LinearProgressBar : Grid
	{
		/// <summary>
		/// The progress property.
		/// </summary>
		public static readonly BindableProperty ProgressProperty = BindableProperty.Create<LinearProgressBar, int>(p => p.Progress, 0);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.LinearProgressBar"/> class.
		/// </summary>
		public LinearProgressBar()
		{
			UpdateProgressBar();
		}

		/// <summary>
		/// Updates the progress bar.
		/// </summary>
		void UpdateProgressBar()
		{
			Padding = new Thickness(0f, 9f, 9f, 10f);
			ColumnDefinitions = new ColumnDefinitionCollection {
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			};
			Children.Add(new Image {
				Source = ImageSource.FromFile("EmptyLinearProgress.png"),
				Aspect = Aspect.AspectFill
			});
			Children.Add(new Image {
				Source = LoadImage(),
				Aspect = Aspect.AspectFill
			});
		}

		/// <summary>
		/// Loads the image.
		/// </summary>
		/// <returns>The image.</returns>
		ImageSource LoadImage()
		{
			if (Progress > 0)
			{
				var percent = Math.Ceiling(Progress / 10f) * 10;
				return ImageSource.FromFile(string.Concat("Progress", percent, ".png"));
			}
			return null;
		}

		/// <summary>
		/// Gets or sets the progress.
		/// </summary>
		/// <value>The progress.</value>
		public int Progress {
			get {
				return (int) GetValue(ProgressProperty);
			}
			set { 
				SetValue(ProgressProperty, value);
				UpdateProgressBar();
			}
		}
	}
}