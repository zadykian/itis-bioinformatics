using System.Linq;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="string"/>.
	/// </summary>
	internal static class StringExtensions
	{
		private static readonly char[] nucleotides = {'a', 't', 'g', 'c'};

		/// <summary>
		/// Определить, является ли <paramref name="stringValue"/> валидной строкой ДНК. 
		/// </summary>
		public static bool IsValidDnaString(this string stringValue)
		{
			if (string.IsNullOrWhiteSpace(stringValue))
			{
				return false;
			}

			return stringValue
				.ToLower()
				.All(character => nucleotides.Contains(character));
		}
	}
}