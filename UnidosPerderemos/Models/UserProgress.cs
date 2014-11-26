using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace UnidosPerderemos.Models
{
	/// <summary>
	/// Progress type.
	/// </summary>
	public enum ProgressType
	{
		Daily,
		Weekly
	}

	/// <summary>
	/// Progress type info.
	/// </summary>
	public static class ProgressTypeInfo
	{
		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public static IDictionary<string, object> GetItems()
		{
			var items = new Dictionary<string, object>();
			items.Add("Diário", ProgressType.Daily);
			items.Add("Semanal", ProgressType.Weekly);
			return items;
		}
	}

	/// <summary>
	/// User progress. 
	/// </summary>
	public class UserProgress : Dedication
	{
		public UserProgress()
		{
		}

		/// <summary>
		/// Gets or sets the object identifier.
		/// </summary>
		/// <value>The object identifier.</value>
		public Object ObjectId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the performance exercise.
		/// </summary>
		/// <value>The performance exercise.</value>
		public Performance PerformanceExercise {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the performance feed.
		/// </summary>
		/// <value>The performance feed.</value>
		public Performance PerformanceFeed {
			get;
			set;
		}

		/// <summary>
		/// Gets the today dedication.
		/// </summary>
		/// <value>The today dedication.</value>
		public long TodayDedication {
			get {
				return (long) PerformanceExercise + (long) PerformanceFeed;
			}
		}

		/// <summary>
		/// Gets or sets the daily dedication.
		/// </summary>
		/// <value>The daily dedication.</value>
		public long DailyDedication {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		public RemoteFile Photo {
			get;
			set;
		} = new RemoteFile {
			Name = "photo.jpeg"
		};

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		/// <value>The comments.</value>
		public string Comments {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>The weight.</value>
		public double Weight {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public ProgressType Type {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date {
			get;
			set;
		}

		/// <summary>
		/// Gets the formatted date.
		/// </summary>
		/// <value>The formatted date.</value>
		public string FormattedDate {
			get {
				return Date.ToString("dd.MM.yyyy");
			}
		}
	}
}