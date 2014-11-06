using System;

namespace UnidosPerderemos.Models
{
	public class DailyProgress
	{
		public DailyProgress()
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
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		byte[] Photo {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		/// <value>The comments.</value>
		public string Comments {
			get;
			set;
		}
	}
}