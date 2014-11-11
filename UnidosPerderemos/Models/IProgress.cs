using System;

namespace UnidosPerderemos.Models
{
	public interface IProgress
	{
		/// <summary>
		/// Gets or sets the object identifier.
		/// </summary>
		/// <value>The object identifier.</value>
		Object ObjectId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		DateTime Date {
			get;
			set;
		}
	}
}