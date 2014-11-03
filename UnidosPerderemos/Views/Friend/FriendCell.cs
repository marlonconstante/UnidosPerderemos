using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.Friend
{
	public class FriendCell : TextCell
	{
		/// <summary>
		/// The identifier friend property.
		/// </summary>
		public static readonly BindableProperty IdFriendProperty = BindableProperty.Create<FriendCell, string>(p => p.IdFriend, string.Empty);

		/// <summary>
		/// The font property.
		/// </summary>
		public static readonly BindableProperty FontProperty = BindableProperty.Create<FriendCell, Font>(p => p.Font, Font.OfSize("Roboto-Light", 20));

		public FriendCell()
		{
			this.SetBinding(IdFriendProperty, "Id");
			this.SetBinding(TextProperty, "Name");

			TextColor = Color.FromHex("464646");
		}

		/// <summary>
		/// Gets or sets the identifier friend.
		/// </summary>
		/// <value>The identifier friend.</value>
		public string IdFriend {
			get {
				return (string) GetValue(IdFriendProperty);
			}
			set {
				SetValue(IdFriendProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font {
			get {
				return (Font) GetValue(FontProperty);
			}
			set {
				SetValue(FontProperty, value);
			}
		}
	}
}