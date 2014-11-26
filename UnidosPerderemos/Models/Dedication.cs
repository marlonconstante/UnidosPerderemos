using System;

namespace UnidosPerderemos.Models
{
	public class Dedication
	{
		public Dedication()
		{
		}

		/// <summary>
		/// Gets or sets the weekly dedication.
		/// </summary>
		/// <value>The weekly dedication.</value>
		public long WeeklyDedication {
			get;
			set;
		}

		/// <summary>
		/// Gets the dedication progress.
		/// </summary>
		/// <value>The dedication progress.</value>
		public int DedicationProgress {
			get {
				return (int) Math.Min(Math.Max(WeeklyDedication * 100d / 28d, 0d), 100d);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is prizewinner.
		/// </summary>
		/// <value><c>true</c> if this instance is prizewinner; otherwise, <c>false</c>.</value>
		public bool IsPrizewinner {
			get {
				return DedicationProgress >= 90;
			}
		}
	}
}