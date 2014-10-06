using System;
using Xamarin.Forms;

namespace UnidosPerderemos
{
	public class ContactCell : ImageCell
	{
		/// <summary>
		/// The identifier property.
		/// </summary>
		public static readonly BindableProperty IdProperty = BindableProperty.Create<ContactCell, string>(p => p.Id, null);

		public ContactCell() : base()
		{
			this.SetBinding(IdProperty, "Id");
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
			var stream = await DependencyService.Get<IAddressBookService>().GetThumbnail(Id);
			ImageSource = ImageSource.FromStream(() => {
				return stream;
			});
		}

		/// <summary>
		/// Gets a value that can be used to uniquely identify an element through the run of an application.
		/// </summary>
		/// <value>A Guid uniquely identifying the element.</value>
		/// <remarks>This value is generated at runtime and is not stable across runs of your app.</remarks>
		public string Id {
			get {
				return (string) GetValue(IdProperty);
			}
			set {
				SetValue(IdProperty, value);
			}
		}
	}
}