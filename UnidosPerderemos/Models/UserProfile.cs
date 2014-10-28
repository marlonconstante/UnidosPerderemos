using System;

namespace UnidosPerderemos.Models
{
	public class UserProfile
	{
		public UserProfile()
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
		/// Gets or sets the date of birth.
		/// </summary>
		/// <value>The date of birth.</value>
		public DateTime DateOfBirth {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		public Gender Gender {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>The weight.</value>
		public float Weight {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public float Height {
			get;
			set;
		}
	}
}