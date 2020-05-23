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
			var stringRepresentation = string.Join(Environment.NewLine,
				alignedSequence.FirstSequence.ToFullString(),
				alignedSequence.SecondSequence.ToFullString());

			var replacementCount = alignedSequence.FirstSequence
				.Zip(alignedSequence.SecondSequence)
				.Count(tuple => tuple.First != '-' && tuple.Second != '-' && tuple.First != tuple.Second);

			var indelCount = alignedSequence.FirstSequence
				.Concat(alignedSequence.SecondSequence)
				.Count(byteValue => byteValue == '-');

			return new AlignmentResult(stringRepresentation, 
				alignedSequence.Score, 
				(uint) replacementCount, 
				(uint) indelCount);
		}
	}
}