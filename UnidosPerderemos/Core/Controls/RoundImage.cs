using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class RoundImage : Image
	{
		/// <summary>
		/// The loading source property.
		/// </summary>
		public static readonly BindableProperty LoadingSourceProperty = BindableProperty.Create<RoundImage, bool>(p => p.LoadingSource, false);

		public RoundImage()
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnidosPerderemos.Core.Controls.RoundImage"/> loading source.
		/// </summary>
		/// <value><c>true</c> if loading source; otherwise, <c>false</c>.</value>
		public bool LoadingSource {
			get {
				return (bool) GetValue(LoadingSourceProperty);
			}
			set {
				SetValue(LoadingSourceProperty, value);
			}
		}
	}
}