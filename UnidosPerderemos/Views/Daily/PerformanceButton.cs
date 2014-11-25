using System;
using Xamarin.Forms;
using UnidosPerderemos.Models;
using UnidosPerderemos.Core.Controls;
using System.Linq;
using System.Collections.Generic;

namespace UnidosPerderemos.Views.Daily
{
	public class PerformanceButton : ContentView
	{
		public PerformanceButton(Performance performance, Action<Performance> selectPerformance)
		{
			Performance = performance;
			SelectPerformance = selectPerformance;

			SetUp();

			Content = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = new GridLength(1d, GridUnitType.Star)
					}
				},
				Children = {
					Box,
					Button
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			IsSelected = false;

			Button.Image = ImageSource.FromFile(string.Concat(Performance.ToString(), ".png")) as FileImageSource;
			Button.Clicked += OnSelectPerformance;
		}

		/// <summary>
		/// Raises the select performance event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnSelectPerformance(object sender, EventArgs args)
		{
			SelectPerformance(Performance);
		}

		/// <summary>
		/// Gets the box.
		/// </summary>
		/// <value>The box.</value>
		BoxView Box {
			get;
		} = new BoxView {
			HeightRequest = 56d
		};

		/// <summary>
		/// Gets the button.
		/// </summary>
		/// <value>The button.</value>
		ImageButton Button {
			get;
		} = new ImageButton();

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
		public bool IsSelected {
			get {
				return Button.Opacity == 1d;
			}
			set {
				Box.BackgroundColor = Color.White.MultiplyAlpha(value ? 0.3d : 0.2d);
				Button.Opacity = value ? 1d : 0.4d;
			}
		}

		/// <summary>
		/// Gets or sets the performance.
		/// </summary>
		/// <value>The performance.</value>
		public Performance Performance {
			get;
			protected set;
		}

		/// <summary>
		/// Gets or sets the select performance.
		/// </summary>
		/// <value>The select performance.</value>
		Action<Performance> SelectPerformance {
			get;
			set;
		}
	}
}