using System;

namespace UnidosPerderemos.Utils
{
	public static class StringExtension
	{
		/// <summary>
		/// Tos the first uppercase.
		/// </summary>
		/// <returns>The first uppercase.</returns>
		/// <param name="text">Text.</param>
		public static string ToFirstUppercase(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			return char.ToUpper(text[0]) + text.Substring(1);
		}

		/// <summary>
		/// Tos the first lowercase.
		/// </summary>
		/// <returns>The first lowercase.</returns>
		/// <param name="text">Text.</param>
		public static string ToFirstLowercase(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			return char.ToLower(text[0]) + text.Substring(1);
		}

		/// <summary>
		/// Parses the double.
		/// </summary>
		/// <returns>The double.</returns>
		/// <param name="text">Text.</param>
		public static double ParseDouble(this string text)
		{
			try {
				return double.Parse(text);
			} catch (Exception ex)
			{
				return 0d;
			}
		}
	}
}