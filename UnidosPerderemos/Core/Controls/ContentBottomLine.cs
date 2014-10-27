using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class ContentBottomLine : ContentView
	{
		public ContentBottomLine()
		{
			SetUp();
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			BoxBottomLine = new BoxView {
				TranslationY = -1d
			};
			BottomLineColor = Color.FromHex("fcff00");
			BottomLineHeight = 2d;
		}

		/// <summary>
		/// Gets the box bottom line.
		/// </summary>
		/// <value>The box bottom line.</value>
		public BoxView BoxBottomLine {
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the color of the bottom line.
		/// </summary>
		/// <value>The color of the bottom line.</value>
		public Color BottomLineColor {
			get {
				return BoxBottomLine.BackgroundColor;
			}
			set {
				BoxBottomLine.BackgroundColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the height of the bottom line.
		/// </summary>
		/// <value>The height of the bottom line.</value>
		public double BottomLineHeight {
			get {
				return BoxBottomLine.HeightRequest;
			}
			set {
				BoxBottomLine.HeightRequest = value;
			}
		}
	}
}