using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class RadialProgressBar : Image
	{
		/// <summary>
		/// The progress property.
		/// </summary>
		public static readonly BindableProperty ProgressProperty = BindableProperty.Create<RadialProgressBar, float>(p => p.Progress, 0, BindingMode.TwoWay);

		/// <summary>
		/// The progress color property.
		/// </summary>
		public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create<RadialProgressBar, Color>(p => p.ProgressColor, Color.Red, BindingMode.TwoWay);

		/// <summary>
		/// Gets or sets the current progress
		/// </summary>
		/// <value>The progress.</value>
		public float Progress
		{
			get { return (float)GetValue(ProgressProperty); }
			set { SetValue(ProgressProperty, value); }
		}

		/// <summary>
		/// Gets or sets the progress color
		/// </summary>
		/// <value>The color of the progress.</value>
		public Color ProgressColor {
			get { return (Color)GetValue (ProgressColorProperty); }
			set { SetValue (ProgressColorProperty, value); }
		}
			
		/// <summary>
		/// Initializes a new instance of the <see cref="UnidosPerderemos.Core.Controls.RadialProgressBar"/> class.
		/// </summary>
		public RadialProgressBar()
		{
		}
	}
}

