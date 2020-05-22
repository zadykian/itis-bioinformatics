using System.Collections.Generic;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="IEnumerable{String}"/>.
	/// </summary>
	internal static class StringEnumerableExtensions
	{
		/// <summary>
		/// Объединить коллекцию строк <paramref name="stringEnumerable"/>,
		/// используя разделитель <paramref name="delimiter"/>. 
		/// </summary>
		public static string JoinBy(this IEnumerable<string> stringEnumerable, string delimiter)
		{
			return stringEnumerable == null
				? string.Empty
				: string.Join(delimiter, stringEnumerable);
		}
	}
}