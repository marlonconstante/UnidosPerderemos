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
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName {
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
		public double Weight {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public double Height {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the goal weight.
		/// </summary>
		/// <value>The goal weight.</value>
		public double GoalWeight {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the goal time.
		/// </summary>
		/// <value>The goal time.</value>
		public double GoalTime {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is tactic exercise.
		/// </summary>
		/// <value><c>true</c> if this instance is tactic exercise; otherwise, <c>false</c>.</value>
		public bool IsTacticExercise {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is tactic feed.
		/// </summary>
		/// <value><c>true</c> if this instance is tactic feed; otherwise, <c>false</c>.</value>
		public bool IsTacticFeed {
			get;
			set;
		}
	}
}