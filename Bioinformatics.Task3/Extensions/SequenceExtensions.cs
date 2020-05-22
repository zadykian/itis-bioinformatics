using System.Linq;
using Bio;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="ISequence"/>.
	/// </summary>
	internal static class SequenceExtensions
	{
		/// <summary>
		/// Получить полное строковое представление последовательности. 
		/// </summary>
		public static string ToFullString(this ISequence sequence)
		{
			return string.Concat(sequence.Cast<char>());
		}
	}
}