using System;
using Xamarin.Forms;
using UnidosPerderemos.Models;
using System.Collections.Generic;

namespace UnidosPerderemos.Views.Weekly
{
	public class WeeklyProgressView : ContentView
	{
		public WeeklyProgressView()
		{
			ConfigColumns();
			ConfigRows();

			AddPerformanceImages();
			AddStarImages();

			RangeView.WeekChanged += (object sender, EventArgs args) => {
				UpdateWeek();
			};

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 0d,
					Padding = new Thickness(0d, 5d, 0d, 0d),
					Children = {
						RangeView,
						GridWeekly
					}
				}
			};
		}

		/// <summary>
		/// Configs the columns.
		/// </summary>
		void ConfigColumns()
		{
			var index = 0;
			foreach (var source in SourceHeaders)
			{
				var contentView = BuildContentView((index == 0) ? 7d : 5d, 0d, new Image { Source = source });
				GridWeekly.ColumnDefinitions.Add(new ColumnDefinition {
					Width = (index == 0) ? 95d : new GridLength(1d, GridUnitType.Star)
				});
				GridWeekly.Children.Add(contentView, index, 0);
				index++;
			}
		}

		/// <summary>
		/// Configs the rows.
		/// </summary>
		void ConfigRows()
		{
			var index = 0;
			foreach (var day in Days)
			{
				var contentView = BuildContentView(9d, (index == 0) ? 0d : 0.4d, BuildLabel(day, "Roboto-Regular"));
				ContentViews.Add(new KeyValuePair<int, int>(index, 0), contentView);
				GridWeekly.RowDefinitions.Add(new RowDefinition {
					Height = (index == 0) ? 40d : 55d
				});
				GridWeekly.Children.Add(contentView, 0, index);
				index++;
			}
		}

		/// <summary>
		/// Adds the performance images.
		/// </summary>
		void AddPerformanceImages()
		{
			foreach (var value in Enum.GetValues(typeof(Performance)))
			{
				PerformanceImages.Add((Performance) value, ImageSource.FromFile(string.Concat(value.ToString(), "Color.png")));
			}
		}

		/// <summary>
		/// Adds the star images.
		/// </summary>
		void AddStarImages()
		{
			StarImages.Add(true, ImageSource.FromFile("FullStar.png"));
			StarImages.Add(false, ImageSource.FromFile("EmptyStar.png"));
		}

		/// <summary>
		/// Updates the week.
		/// </summary>
		void UpdateWeek()
		{
			if (ActivityIndicator != null)
			{
				ActivityIndicator.IsVisible = true;
			}
			var isPrizewinner = false;
			for (var row = 1; row < Days.Length; row++)
			{
				var userProgress = GetDailyProgress(RangeView.CurrentStartOfWeek.AddDays(row - 1d));
				isPrizewinner = isPrizewinner || userProgress.IsPrizewinner;
				for (var column = 1; column < SourceHeaders.Length; column++)
				{
					var key = new KeyValuePair<int, int>(row, column);
					if (!ContentViews.ContainsKey(key))
					{
						var contentView = BuildContentView(0d, 0.3d, new Image { TranslationX = -4d });
						ContentViews.Add(key, contentView);
						GridWeekly.Children.Add(contentView, column, row);
					}
					UpdateContentView(key, userProgress);
				}
			}
			UpdateStarContent(GridWeekly, isPrizewinner);
			if (ActivityIndicator != null)
			{
				Device.BeginInvokeOnMainThread(() => {
					ActivityIndicator.IsVisible = false;
				});
			}
		}

		/// <summary>
		/// Updates the content view.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="userProgress">User progress.</param>
		void UpdateContentView(KeyValuePair<int, int> key, UserProgress userProgress)
		{
			ContentView contentView;
			if (ContentViews.TryGetValue(key, out contentView))
			{
				switch (key.Value)
				{
					case 1:
						UpdatePerformanceImage((Image) contentView.Content, userProgress.PerformanceExercise);
						break;
					case 2:
						UpdatePerformanceImage((Image) contentView.Content, userProgress.PerformanceFeed);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Updates the content of the star.
		/// </summary>
		/// <param name="grid">Grid.</param>
		/// <param name="full">If set to <c>true</c> full.</param>
		async void UpdateStarContent(Grid grid, bool full)
		{
			var contentView = grid.Children[0] as ContentView;
			var image = contentView.Content as Image;

			ImageSource source;
			if (StarImages.TryGetValue(full, out source))
			{
				Device.BeginInvokeOnMainThread(() => {
					image.Source = source;
					image.Opacity = full ? 1d : 0.5d;
				});
			}
		}

		/// <summary>
		/// Updates the performance image.
		/// </summary>
		/// <param name="image">Image.</param>
		/// <param name="performance">Performance.</param>
		async void UpdatePerformanceImage(Image image, Performance performance)
		{
			ImageSource source;
			if (PerformanceImages.TryGetValue(performance, out source))
			{
				Device.BeginInvokeOnMainThread(() => {
					image.Source = source;
				});
			}	
		}

		/// <summary>
		/// Gets the daily progress.
		/// </summary>
		/// <returns>The daily progress.</returns>
		/// <param name="date">Date.</param>
		UserProgress GetDailyProgress(DateTime date)
		{
			UserProgress userProgress;
			DateProgress.TryGetValue(date, out userProgress);
			return userProgress ?? EmptyUserProgress;
		}

		/// <summary>
		/// Builds the label.
		/// </summary>
		/// <returns>The label.</returns>
		/// <param name="text">Text.</param>
		/// <param name="fontFamily">Font family.</param>
		Label BuildLabel(string text, string fontFamily)
		{
			return new Label {
				Text = text,
				TextColor = Color.FromHex("2e3192"),
				FontFamily = fontFamily,
				FontSize = 18.5d,
				YAlign = TextAlignment.Center
			};
		}

		/// <summary>
		/// Builds the content view.
		/// </summary>
		/// <returns>The content view.</returns>
		/// <param name="padding">Padding.</param>
		/// <param name="backgroundOpacity">Background opacity.</param>
		/// <param name="content">Content.</param>
		ContentView BuildContentView(double padding, double backgroundOpacity, View content)
		{
			return new ContentView {
				Content = content,
				Padding = padding,
				BackgroundColor = Color.White.MultiplyAlpha(backgroundOpacity)
			};
		}

		/// <summary>
		/// Gets the source headers.
		/// </summary>
		/// <value>The source headers.</value>
		ImageSource[] SourceHeaders {
			get;
		} = new ImageSource[] { null, ImageSource.FromFile("BenchPresses.png"), ImageSource.FromFile("Apple.png") };

		/// <summary>
		/// Gets the days.
		/// </summary>
		/// <value>The days.</value>
		string[] Days {
			get;
		} = new string[] { string.Empty, "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo" };

		/// <summary>
		/// Gets the content views.
		/// </summary>
		/// <value>The content views.</value>
		Dictionary<KeyValuePair<int, int>, ContentView> ContentViews {
			get;
		} = new Dictionary<KeyValuePair<int, int>, ContentView>();

		/// <summary>
		/// Gets the performance images.
		/// </summary>
		/// <value>The performance images.</value>
		Dictionary<Performance, ImageSource> PerformanceImages {
			get;
		} = new Dictionary<Performance, ImageSource>();

		/// <summary>
		/// Gets the star images.
		/// </summary>
		/// <value>The star images.</value>
		Dictionary<bool, ImageSource> StarImages {
			get;
		} = new Dictionary<bool, ImageSource>();

		/// <summary>
		/// Gets the date progress.
		/// </summary>
		/// <value>The date progress.</value>
		Dictionary<DateTime, UserProgress> DateProgress {
			get;
		} = new Dictionary<DateTime, UserProgress>();

		/// <summary>
		/// Gets the empty user progress.
		/// </summary>
		/// <value>The empty user progress.</value>
		UserProgress EmptyUserProgress {
			get;
		} = new UserProgress();

		/// <summary>
		/// Gets the range view.
		/// </summary>
		/// <value>The range view.</value>
		WeeklyRangeView RangeView {
			get;
		} = new WeeklyRangeView();

		/// <summary>
		/// Gets the grid weekly.
		/// </summary>
		/// <value>The grid weekly.</value>
		Grid GridWeekly {
			get;
		} = new Grid {
			ColumnSpacing = 1d,
			RowSpacing = 1d
		};

		/// <summary>
		/// Sets the items source.
		/// </summary>
		/// <value>The items source.</value>
		public IEnumerable<UserProgress> ItemsSource {
			set {
				var dates = new List<DateTime>();
				DateProgress.Clear();
				foreach (var userProgress in value)
				{
					dates.Add(userProgress.Date);
					DateProgress.Add(userProgress.Date, userProgress);
				}
				RangeView.UpdateDateRange(dates);
				UpdateWeek();
			}
		}

		/// <summary>
		/// Gets or sets the activity indicator.
		/// </summary>
		/// <value>The activity indicator.</value>
		public ActivityIndicator ActivityIndicator {
			get;
			set;
		}
	}
}