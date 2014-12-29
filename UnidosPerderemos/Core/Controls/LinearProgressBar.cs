using System;
using Xamarin.Forms;
using System.Collections.Generic;

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
					Width = 194d
				}
			};
			Children.Add(EmptyProgressImage);
			Children.Add(ProgressImage);

			AddImageSources();
		}

		/// <summary>
		/// Adds the image sources.
		/// </summary>
		void AddImageSources()
		{
			ImageSources.Clear();

			for (var index = 1; index <= 10; index++)
			{
				ImageSources.Add(index, ImageSource.FromFile(string.Concat("Progress", index * 10, ".png")));
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
		/// Gets the progress image source.
		/// </summary>
		/// <value>The progress image source.</value>
		ImageSource ProgressImageSource {
			get {
				ImageSource source = null;
				if (Progress > 0)
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
		/// Gets the image sources.
		/// </summary>
		/// <value>The image sources.</value>
		Dictionary<int, ImageSource> ImageSources {
			get;
		} = new Dictionary<int, ImageSource>();
	}
}