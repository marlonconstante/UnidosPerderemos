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

		/// <summary>
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		public RemoteFile Photo {
			get;
			set;
		} = new RemoteFile {
			Name = "photo.jpeg"
		};

		/// <summary>
		/// Gets or sets the date start.
		/// </summary>
		/// <value>The date start.</value>
		public DateTime DateStart {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the date last daily.
		/// </summary>
		/// <value>The date last daily.</value>
		public DateTime DateLastDaily {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the date last weekly.
		/// </summary>
		/// <value>The date last weekly.</value>
		public DateTime DateLastWeekly {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is daily performed.
		/// </summary>
		/// <value><c>true</c> if this instance is daily performed; otherwise, <c>false</c>.</value>
		public bool IsDailyPerformed {
			get {
				return DateLastDaily == DateTime.Now.Date;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is weekly performed.
		/// </summary>
		/// <value><c>true</c> if this instance is weekly performed; otherwise, <c>false</c>.</value>
		public bool IsWeeklyPerformed {
			get {
				return (DateTime.Now.Date - DateLastWeekly).TotalDays <= 7;
			}
		}

		/// <summary>
		/// Gets the type of the current progress.
		/// </summary>
		/// <value>The type of the current progress.</value>
		public ProgressType CurrentProgressType {
			get {
 				return (DateLastDaily == DateLastWeekly || !IsWeeklyPerformed) ? ProgressType.Weekly : ProgressType.Daily;
			}
		}
	}
}