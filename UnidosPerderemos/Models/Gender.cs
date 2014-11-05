using System;
using System.Collections.Generic;

namespace UnidosPerderemos.Models
{
	/// <summary>
	/// Gender.
	/// </summary>
	public enum Gender
	{
		Male,
		Female
	}

	/// <summary>
	/// Gender info.
	/// </summary>
	public static class GenderInfo
	{
		/// <summary>
		/// Gets the gender items.
		/// </summary>
		/// <returns>The gender items.</returns>
		public static IDictionary<string, object> GetGenderItems()
		{
			var genderItems = new Dictionary<string, object>();
			genderItems.Add("Masculino", Gender.Male);
			genderItems.Add("Feminino", Gender.Female);
			return genderItems;
		}
	}
}