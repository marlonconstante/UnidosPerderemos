using System;
using Parse;
using UnidosPerderemos.Utils;
using UnidosPerderemos.Models;

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
			SetPropertyValue("ObjectId", target, source.ObjectId);
			foreach (var key in source.Keys)
			{
				object value;
				if (source.TryGetValue(key, out value))
				{
					SetPropertyValue(key.ToFirstUppercase(), target, value);
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
				if ("ObjectId".Equals(property.Name))
				{
					target.ObjectId = (string) value;
				}
				else if (property.CanWrite && IsAddValue(value))
				{
					if (value is Enum)
					{
						value = value.ToString();
					}
					else if (value is RemoteFile)
					{
						value = ((RemoteFile) value).ToParseFile();
					}
					target.Add(property.Name.ToFirstLowercase(), value);
				}
			}
			return target;
		}

		/// <summary>
		/// Determines if is add value the specified value.
		/// </summary>
		/// <returns><c>true</c> if is add value the specified value; otherwise, <c>false</c>.</returns>
		/// <param name="value">Value.</param>
		static bool IsAddValue(object value)
		{
			return !(value is RemoteFile) || ((RemoteFile) value).IsLoaded;
		}

		/// <summary>
		/// Sets the property value.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="target">Target.</param>
		/// <param name="value">Value.</param>
		static void SetPropertyValue(string name, object target, object value)
		{
			var property = target.GetType().GetProperty(name);
			if (property != null)
			{
				if (property.PropertyType.IsEnum)
				{
					value = Enum.Parse(property.PropertyType, value.ToString());
				}
				else if (value is ParseFile)
				{
					value = ((ParseFile) value).ToRemoteFile();
				}
				property.SetValue(target, value);
			}
		}
	}
}