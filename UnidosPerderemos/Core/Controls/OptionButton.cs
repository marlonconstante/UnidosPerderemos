using System;
using Xamarin.Forms;
using UnidosPerderemos.Models;
using System.Collections.Generic;

namespace UnidosPerderemos.Core.Controls
{
	public class OptionButton : View
	{
		/// <summary>
		/// The selected item property.
		/// </summary>
		public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create<OptionButton, string>(p => p.SelectedItem, null);

		/// <summary>
		/// The items property.
		/// </summary>
		public static readonly BindableProperty ItemsProperty = BindableProperty.Create<OptionButton, IList<string>>(p => p.Items, new string[] {});

		public OptionButton()
		{
		}

		/// <summary>
		/// Gets or sets the selected item.
		/// </summary>
		/// <value>The selected item.</value>
		public string SelectedItem {
			get {
				return (string) GetValue(SelectedItemProperty);
			}
			set {
				SetValue(SelectedItemProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>The items.</value>
		public IList<string> Items {
			get {
				return (IList<string>) GetValue(ItemsProperty);
			}
			set {
				SetValue(ItemsProperty, value);
			}
		}
	}
}