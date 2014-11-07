﻿using System;
using Xamarin.Forms;
using UnidosPerderemos.Core.Controls;
using UnidosPerderemos.Models;

namespace UnidosPerderemos.Views.Daily
{
	public class PerformanceViewBox : ContentView
	{
		public PerformanceViewBox()
		{
			Content = new StackLayout {
				Spacing = 5d,
				Children = {
					IconLabel,
					GridPerformance
				}
			};
		}

		/// <summary>
		/// Gets the icon label.
		/// </summary>
		/// <value>The icon label.</value>
		IconLabel IconLabel {
			get;
		} = new IconLabel {
			TranslationX = 15d,
			IconWidth = 29d,
			Font = Font.OfSize("Roboto-Thin", 24)
		};

		/// <summary>
		/// Gets the grid performance.
		/// </summary>
		/// <value>The grid performance.</value>
		Grid GridPerformance {
			get {
				return new Grid {
					ColumnSpacing = 1d,
					ColumnDefinitions = {
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						},
						new ColumnDefinition {
							Width = new GridLength(1d, GridUnitType.Star)
						}
					},
					Children = {
						{ ButtonPoor, 0, 0 },
						{ ButtonAverage, 1, 0 },
						{ ButtonFine, 2, 0 }
					}
				};
			}
		}

		/// <summary>
		/// Gets the button poor.
		/// </summary>
		/// <value>The button poor.</value>
		PerformanceButton ButtonPoor {
			get {
				return new PerformanceButton(Performance.Poor, SelectPerformance);
			}
		}

		/// <summary>
		/// Gets the button average.
		/// </summary>
		/// <value>The button average.</value>
		PerformanceButton ButtonAverage {
			get {
				return new PerformanceButton(Performance.Average, SelectPerformance);
			}
		}

		/// <summary>
		/// Gets the button fine.
		/// </summary>
		/// <value>The button fine.</value>
		PerformanceButton ButtonFine {
			get {
				return new PerformanceButton(Performance.Fine, SelectPerformance);
			}
		}

		/// <summary>
		/// Selects the performance.
		/// </summary>
		/// <param name="performance">Performance.</param>
		void SelectPerformance(Performance performance) {
			SelectedPerformance = performance;
		}

		/// <summary>
		/// Gets or sets the selected performance.
		/// </summary>
		/// <value>The selected performance.</value>
		public Performance SelectedPerformance {
			get;
			protected set;
		}

		/// <summary>
		/// Gets or sets the icon text.
		/// </summary>
		/// <value>The icon text.</value>
		public string IconText {
			get {
				return IconLabel.Text;
			}
			set {
				IconLabel.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the icon image.
		/// </summary>
		/// <value>The icon image.</value>
		public ImageSource IconImage {
			get {
				return IconLabel.Image;
			}
			set {
				IconLabel.Image = value;
			}
		}
	}
}