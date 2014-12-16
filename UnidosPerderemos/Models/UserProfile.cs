using System;

namespace UnidosPerderemos.Models
{
	public class UserProfile : Dedication
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
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public double Height {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the initial weight.
		/// </summary>
		/// <value>The initial weight.</value>
		public double InitialWeight {
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
		/// Gets the desired weight.
		/// </summary>
		/// <value>The desired weight.</value>
		public double DesiredWeight {
			get {
				return InitialWeight - GoalWeight;
			}
		}

		/// <summary>
		/// Gets the lost weight.
		/// </summary>
		/// <value>The lost weight.</value>
		public double LostWeight {
			get {
				return InitialWeight - Weight;
			}
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
		/// Gets or sets the start date.
		/// </summary>
		/// <value>The start date.</value>
		public DateTime StartDate {
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
		/// Gets or sets the date last prize.
		/// </summary>
		/// <value>The date last prize.</value>
		public DateTime? DateLastPrize {
			get;
			set;
		}

		/// <summary>
		/// Gets the prize weeks.
		/// </summary>
		/// <value>The prize weeks.</value>
		public int PrizeWeeks {
			get {
				if (DateLastPrize == null)
				{
					return 0;
				}
				else
				{
					return ((DateTime.Now.Date - DateLastPrize.Value).Days / 7) + 1;
				}
			}
		}

		/// <summary>
		/// Determines whether this instance is changed date last prize.
		/// </summary>
		/// <returns><c>true</c> if this instance is changed date last prize; otherwise, <c>false</c>.</returns>
		public bool IsChangedDateLastPrize()
		{
			if (IsPrizewinner)
			{
				if (DateLastPrize == null)
				{
					DateLastPrize = DateTime.Now.Date;
					return true;
				}
			}
			else if (DateLastPrize != null)
			{
				DateLastPrize = null;
				return true;
			}
			return false;
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
				return (DateTime.Now.Date - DateLastWeekly).TotalDays < 7;
			}
		}

		/// <summary>
		/// Gets the elapsed time.
		/// </summary>
		/// <value>The elapsed time.</value>
		public double ElapsedTime {
			get {
				if (GoalTime > 0d)
				{
					return 1d + GoalTime - (StartDate.AddDays(GoalTime) - DateTime.Now.Date).TotalDays;
				}
				return 0d;
			}
		}

		/// <summary>
		/// Gets the daily progress.
		/// </summary>
		/// <value>The daily progress.</value>
		public int DailyProgress {
			get {
				if (GoalTime > 0d)
				{
					return (int) Math.Min(Math.Max(ElapsedTime * 100d / GoalTime, 0d), 100d);
				}
				return 0;
			}
		}

		/// <summary>
		/// Gets the goal progress.
		/// </summary>
		/// <value>The goal progress.</value>
		public int GoalProgress {
			get {
				if (GoalWeight > 0d)
				{
					return (int) Math.Min(Math.Max(LostWeight / GoalWeight * 100d, 0d), 100d);
				}
				return 0;
			}
		}
	}
}