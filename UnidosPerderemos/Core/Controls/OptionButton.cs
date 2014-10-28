﻿using System;
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
		public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create<OptionButton, object>(p => p.SelectedItem, null);

		/// <summary>
		/// The items property.
		/// </summary>
		public static readonly BindableProperty ItemsProperty = BindableProperty.Create<OptionButton, IDictionary<string, object>>(p => p.Items, null);

		public OptionButton()
		{
		}

		/// <summary>
		/// Gets or sets the selected item.
		/// </summary>
		/// <value>The selected item.</value>
		public object SelectedItem {
			get {
				return (object) GetValue(SelectedItemProperty);
			}
			set {
				SetValue(SelectedItemProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>The items.</value>
		public IDictionary<string, object> Items {
			get {
				return (IDictionary<string, object>) GetValue(ItemsProperty);
			}
			set {
				SetValue(ItemsProperty, value);
			}
		}
	}
}