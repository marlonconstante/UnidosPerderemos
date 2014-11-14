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
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public static IDictionary<string, object> GetItems()
		{
			var items = new Dictionary<string, object>();
			items.Add("Masculino", Gender.Male);
			items.Add("Feminino", Gender.Female);
			return items;
		}
	}
}