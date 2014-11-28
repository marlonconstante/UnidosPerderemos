using Xamarin.Forms;
using System;
using System.Collections.Generic;

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
		/// Adds the image sources.
		/// </summary>
		void AddImageSources()
		{
			ImageSources.Clear();

			for (var index = 1; index <= 10; index++)
			{
				ImageSources.Add(index, ImageSource.FromFile(string.Concat(Type.ToString(), index * 10, ".png")));
			}
		}

		/// <summary>
		/// Updates the progress bar.
		/// </summary>
		void UpdateProgressBar()
		{
			ProgressImage.Source = ProgressImageSource;
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
		/// Gets the progress image source.
		/// </summary>
		/// <value>The progress image source.</value>
		ImageSource ProgressImageSource {
			get {
				ImageSource source = null;
				if (Progress > 0 && Type != RadialProgressType.Unknown)
				{
					var key = (Progress < 10) ? Math.Ceiling(Progress / 10d) : Math.Floor(Progress / 10d);
					ImageSources.TryGetValue((int) key, out source);
				}
				return source;
			}
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

				AddImageSources();
				UpdateProgressBar();
			}
		}

		/// <summary>
		/// Gets the image sources.
		/// </summary>
		/// <value>The image sources.</value>
		Dictionary<int, ImageSource> ImageSources {
			get;
		} = new Dictionary<int, ImageSource>();
	}
}