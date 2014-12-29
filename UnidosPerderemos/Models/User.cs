using System;
using System.Collections;

namespace UnidosPerderemos.Models
{
	public class User
	{
		public User()
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
		/// Gets or sets the facebook identifier.
		/// </summary>
		/// <value>The facebook identifier.</value>
		public string FacebookId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
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
		/// Gets or sets the email address.
		/// </summary>
		/// <value>The email address.</value>
		public string EmailAddress {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is registration finished.
		/// </summary>
		/// <value><c>true</c> if this instance is registration finished; otherwise, <c>false</c>.</value>
		public bool IsRegistrationFinished {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is facebook user.
		/// </summary>
		/// <value><c>true</c> if this instance is facebook user; otherwise, <c>false</c>.</value>
		public bool IsFacebookUser {
			get {
				return !string.IsNullOrEmpty(FacebookId);
			}
		}
	}
}