using Bio.Algorithms.Alignment;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="IAlignedSequence"/>.
	/// </summary>
	internal static class AlignedSequenceExtensions
	{
		/// <summary>
		/// Получить значение весовой функции выровненных последовательностей.
		/// </summary>
		public static long GetScore(this IAlignedSequence alignedSequence)
		{
			return alignedSequence.Metadata.TryGetValue("Score", out var score)
				? (long) score
				: long.MinValue;
		}
	}
}