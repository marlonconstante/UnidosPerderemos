using System;
using System.Collections.Generic;

namespace UnidosPerderemos
{
	public class PersonContact
	{
		public PersonContact()
		{
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
		/// Gets or sets the phones.
		/// </summary>
		/// <value>The phones.</value>
		public IList<string> Phones {
			get;
			set;
		}

		/// <summary>
		/// Gets the phones text.
		/// </summary>
		/// <value>The phones text.</value>
		public string PhonesText {
			get {
				return string.Join(", ", Phones);
			}
		}

		/// <summary>
		/// Gets or sets the emails.
		/// </summary>
		/// <value>The emails.</value>
		public IList<string> Emails {
			get;
			set;
		}

		/// <summary>
		/// Gets the emails text.
		/// </summary>
		/// <value>The emails text.</value>
		public string EmailsText {
			get {
				return string.Join(", ", Emails);
			}
		}
	}
}