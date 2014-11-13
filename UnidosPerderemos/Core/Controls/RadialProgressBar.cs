using Xamarin.Forms;
using System;

namespace UnidosPerderemos.Core.Controls
{
	/// <summary>
	/// Radial progress type.
	/// </summary>
	public enum RadialProgressType
	{
		Unknown,
		Dedication,
		Goal
	}

	/// <summary>
	/// Radial progress bar.
	/// </summary>
	public class RadialProgressBar : Grid
	{
		/// <summary>
		/// The progress property.
		/// </summary>
		public static readonly BindableProperty ProgressProperty = BindableProperty.Create<RadialProgressBar, int>(p => p.Progress, 0);

		/// <summary>
		/// The type property.
		/// </summary>
		public static readonly BindableProperty TypeProperty = BindableProperty.Create<RadialProgressBar, RadialProgressType>(p => p.Type, RadialProgressType.Unknown);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.RadialProgressBar"/> class.
		/// </summary>
		public RadialProgressBar()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			ColumnDefinitions = new ColumnDefinitionCollection {
				new ColumnDefinition {
					Width = new GridLength(1d, GridUnitType.Star)
				}
			};
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
			if (Progress > 0 && Type != RadialProgressType.Unknown)
			{
				var value = (Progress < 10) ? Math.Ceiling(Progress / 10d) : Math.Floor(Progress / 10d);
				return ImageSource.FromFile(string.Concat(Type.ToString(), value * 10, ".png"));
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

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public RadialProgressType Type {
			get {
				return (RadialProgressType) GetValue(TypeProperty);
			}
			set {
				SetValue(TypeProperty, value);

				UpdateProgressBar();
			}
		}
	}
}