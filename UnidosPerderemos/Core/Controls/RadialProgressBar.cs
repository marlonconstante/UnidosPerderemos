using Xamarin.Forms;
using System;

namespace UnidosPerderemos.Core.Controls
{
	public class RadialProgressBar : Grid
	{
		/// <summary>
		/// The progress property.
		/// </summary>
		public static readonly BindableProperty ProgressProperty = BindableProperty.Create<RadialProgressBar, int>(p => p.Progress, 0);

		/// <summary>
		/// The progress type property.
		/// </summary>
		public static readonly BindableProperty ProgressTypeProperty = BindableProperty.Create<RadialProgressBar, string>(p => p.ProgressType, string.Empty);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.RadialProgressBar"/> class.
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
				return ImageSource.FromFile(string.Concat(ProgressType, percent, ".png"));
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

		/// <summary>
		/// Gets or sets the type of the progress.
		/// </summary>
		/// <value>The type of the progress.</value>
		public string ProgressType {
			get {
				return (string) GetValue(ProgressTypeProperty);
			}
			set { 
				SetValue(ProgressTypeProperty, value);
				UpdateProgressBar();
			}
		}
	}
}