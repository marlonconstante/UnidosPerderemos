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
					Padding = new Thickness(5d),
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
			foreach (var title in Titles)
			{
				GridWeekly.ColumnDefinitions.Add(new ColumnDefinition {
					Width = (index == 0) ? 40d : new GridLength(1d, GridUnitType.Star)
				});
				GridWeekly.Children.Add(BuildLabel(title, "Roboto-Light"), index, 0);
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
				GridWeekly.RowDefinitions.Add(new RowDefinition {
					Height = (index == 0) ? 23d : 53d
				});
				GridWeekly.Children.Add(BuildLabel(day, "Roboto-LightItalic"), 0, index);
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
				PerformanceImages.Add((Performance) value, ImageSource.FromFile(string.Concat(value.ToString(), ".png")));
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
			for (var row = 1; row < Days.Length; row++)
			{
				var userProgress = GetDailyProgress(RangeView.CurrentStartOfWeek.AddDays(row - 1d));
				for (var column = 1; column < Titles.Length; column++)
				{
					var key = new KeyValuePair<int, int>(row, column);
					if (!ContentViews.ContainsKey(key))
					{
						var contentView = BuildContentView((column == 3) ? 5d : 0d);
						ContentViews.Add(key, contentView);
						GridWeekly.Children.Add(contentView, column, row);
					}
					UpdateContentView(key, userProgress);
				}
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
						contentView.Content = BuildPerformanceImage(userProgress.PerformanceExercise);
						break;
					case 2:
						contentView.Content = BuildPerformanceImage(userProgress.PerformanceFeed);
						break;
					case 3:
						contentView.Content = BuildStarImage(false);
						break;
					default:
						break;
				}
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
				TextColor = Color.FromHex("59135d"),
				FontFamily = fontFamily,
				FontSize = 15d,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};
		}

		/// <summary>
		/// Builds the performance image.
		/// </summary>
		/// <returns>The performance image.</returns>
		/// <param name="performance">Performance.</param>
		Image BuildPerformanceImage(Performance performance)
		{
			ImageSource source;
			if (PerformanceImages.TryGetValue(performance, out source))
			{
				return new Image {
					Source = source,
					TranslationX = -4d
				};
			}
			return null;
		}

		/// <summary>
		/// Builds the star image.
		/// </summary>
		/// <returns>The star image.</returns>
		/// <param name="full">If set to <c>true</c> full.</param>
		Image BuildStarImage(bool full)
		{
			ImageSource source;
			if (StarImages.TryGetValue(full, out source))
			{
				return new Image {
					Source = source
				};
			}
			return null;
		}

		/// <summary>
		/// Builds the content view.
		/// </summary>
		/// <returns>The content view.</returns>
		/// <param name="padding">Padding.</param>
		ContentView BuildContentView(double padding)
		{
			return new ContentView {
				Padding = padding,
				BackgroundColor = Color.White.MultiplyAlpha(0.2d)
			};
		}

		/// <summary>
		/// Gets the titles.
		/// </summary>
		/// <value>The titles.</value>
		string[] Titles {
			get;
		} = new string[] { string.Empty, "Exercícios", "Alimentação", string.Empty };

		/// <summary>
		/// Gets the days.
		/// </summary>
		/// <value>The days.</value>
		string[] Days {
			get;
		} = new string[] { string.Empty, "SEG", "TER", "QUA", "QUI", "SEX", "SÁB", "DOM" };

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
				DateProgress.Clear();
				foreach (var userProgress in value)
				{
					DateProgress.Add(userProgress.Date, userProgress);
				}
				UpdateWeek();
			}
		}
	}
}