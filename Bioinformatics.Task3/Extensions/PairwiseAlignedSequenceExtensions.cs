using System;
using System.Linq;
using Bio.Algorithms.Alignment;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="PairwiseAlignedSequence"/>.
	/// </summary>
	internal static class PairwiseAlignedSequenceExtensions
	{
		/// <summary>
		/// Преобразовать <paramref name="alignedSequence"/> в экземпляр <see cref="AlignmentResult"/>.
		/// </summary>
		public static AlignmentResult ToAlignmentResult(this PairwiseAlignedSequence alignedSequence)
		{
			var indices = alignedSequence.FirstSequence
				.Zip(alignedSequence.SecondSequence)
				.Where(tuple => tuple.First != tuple.Second)
				.Select((_, index) => (uint) index)
				.ToArray();

			var alignedStrings = new AlignedStrings(
				alignedSequence.FirstSequence.ToFullString(),
				alignedSequence.SecondSequence.ToFullString(),
				indices);

			var replacementCount = alignedSequence.FirstSequence
				.Zip(alignedSequence.SecondSequence)
				.Count(tuple => tuple.First != '-' && tuple.Second != '-' && tuple.First != tuple.Second);

			var indelCount = alignedSequence.FirstSequence
				.Concat(alignedSequence.SecondSequence)
				.Count(byteValue => byteValue == '-');

			return new AlignmentResult(alignedStrings, 
				alignedSequence.Score, 
				(uint) replacementCount, 
				(uint) indelCount);
		}
	}
}