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
					if (property != null)
					{
						if (property.PropertyType.IsEnum)
						{
							value = Enum.Parse(property.PropertyType, value.ToString());
						}
						property.SetValue(target, value);
					}
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
			T target;
			if (typeof(T) == typeof(ParseObject))
			{
				target = (T) Activator.CreateInstance(typeof(T), source.GetType().Name);
			}
			else
			{
				target = Activator.CreateInstance<T>();
			}
			foreach (var property in source.GetType().GetProperties())
			{
				var value = property.GetValue(source);
				if (value is Enum)
				{
					value = value.ToString();
				}
				target.Add(property.Name.ToFirstLowercase(), value);
			}
			return target;
		}
	}
}