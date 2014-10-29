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
		public static readonly BindableProperty ProgressTypeProperty = BindableProperty.Create<RadialProgressBar, string>(p => p.ProgressType, string.Empty, BindingMode.TwoWay);

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
		public string ProgressType
		{
			get { return (string)GetValue(ProgressTypeProperty); }
			set { SetValue(ProgressTypeProperty, value); }
		}
	}
}