using System;
using System.Collections.Generic;

namespace UnidosPerderemos.Models
{
	public enum Gender
	{
		Male,
		Female
	}

	/// <summary>
	/// Gender info.
	/// </summary>
	static public class GenderInfo
	{
		/// <summary>
		/// Gets the gender items.
		/// </summary>
		/// <returns>The gender items.</returns>
		static public IDictionary<string, object> GetGenderItems()
		{
			var genderItems = new Dictionary<string, object>();
			genderItems.Add("Masculino", Gender.Male);
			genderItems.Add("Feminino", Gender.Female);
			return genderItems;
		}
	}


}