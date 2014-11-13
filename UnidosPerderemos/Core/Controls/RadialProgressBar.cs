using Xamarin.Forms;
using System;

namespace UnidosPerderemos.Core.Controls
{
	public class RadialProgressBar : Grid
	{
		/// <summary>
		/// The progress property.
		/// </summary>
		public static readonly BindableProperty ProgressProperty = BindableProperty.Create<RadialProgressBar, float>(p => p.Progress, 0, BindingMode.TwoWay);

		/// <summary>
		/// The progress color property.
		/// </summary>
		public static readonly BindableProperty ProgressTypeProperty = BindableProperty.Create<RadialProgressBar, string>(p => p.ProgressType, string.Empty, BindingMode.TwoWay);

		/// <summary>
		/// Gets or sets the current progress
		/// </summary>
		/// <value>The progress.</value>
		public float Progress {
			get { return (float) GetValue(ProgressProperty); }
			set { 
				SetValue(ProgressProperty, value); 
				UpdateProgressBar();
			}
		}

		/// <summary>
		/// Gets or sets the progress color
		/// </summary>
		/// <value>The color of the progress.</value>
		public string ProgressType {
			get { return (string) GetValue(ProgressTypeProperty); }
			set { 
				SetValue(ProgressTypeProperty, value); 
				UpdateProgressBar();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.LinearProgressBar"/> class.
		/// </summary>
		public RadialProgressBar()
		{
			UpdateProgressBar();
		}

		/// <summary>
		/// Updates the progress bar.
		/// </summary>
		void UpdateProgressBar()
		{
			ColumnDefinitions = new ColumnDefinitionCollection {
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			};

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
				return ImageSource.FromFile(string.Concat(ProgressType, Progress, ".png"));
			}

			return null;
		}
	}
}