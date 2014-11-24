using System;
using System.Globalization;

namespace UnidosPerderemos.Utils
{
	public static class DateTimeExtension
	{
		/// <summary>
		/// The first day of week.
		/// </summary>
		const DayOfWeek FirstDayOfWeek = DayOfWeek.Monday;

		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <returns>The of year.</returns>
		/// <param name="date">Date.</param>
		public static int WeekOfYear(this DateTime date)
		{
			var calendar = CultureInfo.CurrentCulture.Calendar;
			return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, FirstDayOfWeek);
		}

		/// <summary>
		/// Starts the of week.
		/// </summary>
		/// <returns>The of week.</returns>
		/// <param name="date">Date.</param>
		public static DateTime StartOfWeek(this DateTime date)
		{
			var days = date.DayOfWeek - FirstDayOfWeek;
			if (days < 0)
			{
				days += 7;
			}
			return date.AddDays(-1 * days).Date;
		}
	}
}