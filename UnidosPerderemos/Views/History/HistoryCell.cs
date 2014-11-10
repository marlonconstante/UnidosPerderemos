using System;
using Xamarin.Forms;
using UnidosPerderemos.Services;

namespace UnidosPerderemos.Views.History
{
	public class HistoryCell: ImageCell
	{
		public static readonly BindableProperty IdContactProperty = BindableProperty.Create<HistoryCell, string>(p => p.IdContact, string.Empty);


		public HistoryCell()
		{
			this.SetBinding(IdContactProperty, "Id");
			this.SetBinding(TextProperty, "Name");
			this.SetBinding(DetailProperty, "PhonesText");
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			LoadThumbnail();
		}

		/// <summary>
		/// Loads the thumbnail.
		/// </summary>
		async void LoadThumbnail()
		{
			var stream = await DependencyService.Get<IAddressBookService>().GetThumbnail(IdContact);
			ImageSource = ImageSource.FromStream(() => {
				return stream;
			});
		}

		/// <summary>
		/// Gets or sets the identifier contact.
		/// </summary>
		/// <value>The identifier contact.</value>
		public string IdContact {
			get {
				return (string) GetValue(IdContactProperty);
			}
			set {
				SetValue(IdContactProperty, value);
			}
		}
	}
}

