using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	/// <summary>
	/// Linear progress bar.
	/// </summary>
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
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Padding = new Thickness(0f, 9f, 9f, 10f);
			ColumnDefinitions = new ColumnDefinitionCollection {
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			};
			Children.Add(EmptyProgressImage);
			Children.Add(ProgressImage);
		}

		/// <summary>
		/// Updates the progress bar.
		/// </summary>
		void UpdateProgressBar()
		{
			ProgressImage.Source = LoadImage();
		}

		/// <summary>
		/// Gets the empty progress image.
		/// </summary>
		/// <value>The empty progress image.</value>
		Image EmptyProgressImage {
			get;
		} = new Image {
			Source = ImageSource.FromFile("EmptyLinearProgress.png"),
			Aspect = Aspect.AspectFill
		};

		/// <summary>
		/// Gets the progress image.
		/// </summary>
		/// <value>The progress image.</value>
		Image ProgressImage {
			get;
		} = new Image {
			Aspect = Aspect.AspectFill
		};

		/// <summary>
		/// Loads the image.
		/// </summary>
		/// <returns>The image.</returns>
		ImageSource LoadImage()
		{
			if (Progress > 0)
			{
				var value = (Progress < 10) ? Math.Ceiling(Progress / 10d) : Math.Floor(Progress / 10d);
				return ImageSource.FromFile(string.Concat("Progress", value * 10, ".png"));
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
				SetValue(ProgressProperty, (value > 100) ? 100 : value);

				UpdateProgressBar();
			}
		}
	}
}