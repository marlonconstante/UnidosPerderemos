using System;
using Parse;
using UnidosPerderemos.Utils;

namespace UnidosPerderemos.iOS.Utils
{
	public static class ParseExtension
	{
		/// <summary>
		/// Tos the domain.
		/// </summary>
		/// <returns>The domain.</returns>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T ToDomain<T>(this ParseObject source)
		{
			var target = Activator.CreateInstance<T>();
			foreach (var key in source.Keys)
			{
				object value;
				if (source.TryGetValue(key, out value))
				{
					var property = target.GetType().GetProperty(key.ToFirstUppercase());
					property.SetValue(target, value);
				}
			}
			return target;
		}

		/// <summary>
		/// Tos the parse object.
		/// </summary>
		/// <returns>The parse object.</returns>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T ToParseObject<T>(this object source) where T : ParseObject
		{
			var target = Activator.CreateInstance<T>();
			foreach (var property in source.GetType().GetProperties())
			{
				target.Add(property.Name.ToFirstLowercase(), property.GetValue(source));
			}
			return target;
		}
	}
}