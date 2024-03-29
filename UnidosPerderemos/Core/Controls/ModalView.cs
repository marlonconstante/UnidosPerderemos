﻿using System;
using Xamarin.Forms;

namespace UnidosPerderemos.Core.Controls
{
	public class ModalView : ContentView
	{
		public ModalView()
		{
			SetUp();

			Content = new GridView {
				Children = {
					BackgroundView,
					DialogView
				}
			};
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		void SetUp()
		{
			Hide();

			CancelClicked += (object sender, EventArgs args) => {
				Hide();
			};
		}

		/// <summary>
		/// Gets the background view.
		/// </summary>
		/// <value>The background view.</value>
		BoxView BackgroundView {
			get {
				return new BoxView {
					BackgroundColor = Color.Black.MultiplyAlpha(0.6d)
				};
			}
		}

		/// <summary>
		/// Gets the dialog view.
		/// </summary>
		/// <value>The dialog view.</value>
		DialogView DialogView {
			get;
		} = new DialogView();

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get {
				return DialogView.Title;
			}
			set {
				DialogView.Title = value;
			}
		}

		/// <summary>
		/// Gets or sets the size of the title font.
		/// </summary>
		/// <value>The size of the title font.</value>
		public double TitleFontSize {
			get {
				return DialogView.TitleFontSize;
			}
			set {
				DialogView.TitleFontSize = value;
			}
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message {
			get {
				return DialogView.Message;
			}
			set {
				DialogView.Message = value;
			}
		}

		/// <summary>
		/// Gets or sets the inner view.
		/// </summary>
		/// <value>The inner view.</value>
		public View InnerView {
			get {
				return DialogView.InnerView;
			}
			set {
				DialogView.InnerView = value;
			}
		}

		/// <summary>
		/// Occurs when cancel clicked.
		/// </summary>
		public event EventHandler CancelClicked {
			add {
				DialogView.CancelClicked += value;
			}
			remove {
				DialogView.CancelClicked -= value;
			}
		}

		/// <summary>
		/// Occurs when confirm clicked.
		/// </summary>
		public event EventHandler ConfirmClicked {
			add {
				DialogView.ConfirmClicked += value;
			}
			remove {
				DialogView.ConfirmClicked -= value;
			}
		}

		/// <summary>
		/// Show this instance.
		/// </summary>
		public virtual void Show()
		{
			Opacity = 1d;
		}

		/// <summary>
		/// Hide this instance.
		/// </summary>
		public virtual void Hide() {
			Opacity = 0d;
		}
	}
}