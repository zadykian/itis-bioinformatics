using System;
using System.Collections.Generic;
using System.Linq;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="IEnumerable{T}"/>.
	/// </summary>
	internal static class EnumerableExtensions
	{
		/// <summary>
		/// Объединить коллекцию <paramref name="enumerable"/>,
		/// используя разделитель <paramref name="delimiter"/>. 
		/// </summary>
		public static string JoinBy<T>(this IEnumerable<T> enumerable, string delimiter)
		{
			return enumerable == null
				? string.Empty
				: string.Join(delimiter, enumerable);
		}

		/// <summary>
		/// Получить все элементы, имеющие максимальные значения свойства. 
		/// </summary>
		public static IEnumerable<T> MaxBy<T, TProperty>(this IEnumerable<T> enumerable, 
			Func<T, TProperty> propertySelector)
			where TProperty : IComparable<TProperty>
		{
			var maxItems = new List<T>();
			TProperty currentMaxProperty = default;

			foreach (var item in enumerable)
			{
				var currentProperty = propertySelector(item);

				if (currentProperty.CompareTo(currentMaxProperty) > 0)
				{
					maxItems.Clear();
				}

				if (currentProperty.CompareTo(currentMaxProperty) >= 0)
				{
					maxItems.Add(item);
				}
			}

			return maxItems;
		}
	}
}