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
			foreach (var view in ParentChildren)
			{
				var button = view as PerformanceButton;
				button.IsSelected = false;
			}
			IsSelected = true;

			SelectPerformance(Performance);
		}
			
		/// <summary>
		/// Gets the parent children.
		/// </summary>
		/// <value>The parent children.</value>
		List<View> ParentChildren {
			get {
				return ParentGrid.Children.Where((view) => view != this).ToList();
			}
		}

		/// <summary>
		/// Gets the parent grid.
		/// </summary>
		/// <value>The parent grid.</value>
		Grid ParentGrid {
			get {
				return ParentView as Grid;
			}
		}

		/// <summary>
		/// Gets the box.
		/// </summary>
		/// <value>The box.</value>
		BoxView Box {
			get {
				return new BoxView {
					BackgroundColor = Color.White.MultiplyAlpha(0.2d),
					HeightRequest = 56d
				};
			}
		}

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
				Button.Opacity = value ? 1d : 0.5d;
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
		public Action<Performance> SelectPerformance {
			get;
			protected set;
		}
	}
}