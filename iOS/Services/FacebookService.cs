using System;
using UnidosPerderemos.Services;
using UnidosPerderemos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.FacebookConnect;

[assembly: Xamarin.Forms.Dependency(typeof(UnidosPerderemos.iOS.Services.FacebookService))]
namespace UnidosPerderemos.iOS.Services
{
	public class FacebookService : IFacebookService
	{
		/// <summary>
		/// Finds all friends.
		/// </summary>
		/// <returns>The all friends.</returns>
		public async Task<IList<PersonFacebook>> FindAllFriends()
		{
			var friends = new List<PersonFacebook>();

			var response = await FBRequest.ForMyFriends.StartAsync();
			var result = response.Result as FBGraphObject;
			var data = result["data"] as NSArray;

			for (var index = 0; index < data.Count; index++)
			{
				var person = data.GetItem<FBGraphPerson>(index);
				friends.Add(new PersonFacebook {
					Id = person.GetId(),
					Name = person.GetName()
				});
			}

			return friends;
		}
	}
}