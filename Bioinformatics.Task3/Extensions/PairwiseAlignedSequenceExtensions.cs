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
		public static AlignmentResult ToAlignmentResult(this PairwiseAlignedSequence alignedSequence,
			TransitionWeights transitionWeights)
		{
			var indices = alignedSequence.FirstSequence
				.Zip(alignedSequence.SecondSequence)
				.Select((tuple, index) => (Bytes: tuple, Index: (uint) index))
				.Where(tuple => tuple.Bytes.First != tuple.Bytes.Second)
				.Select(tuple => tuple.Index)
				.ToArray();

			var alignedStrings = new AlignedStrings(
				alignedSequence.FirstSequence.ToFullString(),
				alignedSequence.SecondSequence.ToFullString(),
				indices);

			var score = alignedSequence.CalculateScore(transitionWeights);

			var replacementCount = alignedSequence.FirstSequence
				.Zip(alignedSequence.SecondSequence)
				.Count(tuple => tuple.First != '-' && tuple.Second != '-' && tuple.First != tuple.Second);

			var indelCount = alignedSequence.FirstSequence
				.Concat(alignedSequence.SecondSequence)
				.Count(byteValue => byteValue == '-');

			return new AlignmentResult(alignedStrings,
				score,
				(uint) replacementCount,
				(uint) indelCount);
		}

		/// <summary>
		/// Посчитать значение весовой функции пары выровненных последовательностей. 
		/// </summary>
		public static long CalculateScore(this PairwiseAlignedSequence alignedSequence, 
			TransitionWeights transitionWeights)
		{
			long CalculateScorePerPair(byte leftByte, byte rightByte)
			{
				if (leftByte == rightByte) return transitionWeights.MatchBonus;
				if (leftByte == '-' || rightByte == '-') return transitionWeights.IndelPenalty;
				return transitionWeights.MismatchPenalty;
			}

			long totalScore = 0;

			var isFirstIndel = true;
			foreach (var (leftByte, rightByte) in alignedSequence.FirstSequence.Zip(alignedSequence.SecondSequence))
			{
				var scorePerPair = CalculateScorePerPair(leftByte, rightByte);

				if (leftByte != '-' && rightByte != '-')
				{
					isFirstIndel = true;
				}

				if (isFirstIndel 
				    && (leftByte == '-' || rightByte == '-')
				    && transitionWeights.GapOpeningPenalty.HasValue)
				{
					isFirstIndel = false;
					totalScore += transitionWeights.GapOpeningPenalty.Value;
				}

				totalScore += scorePerPair;
			}

			return totalScore;
		}
	}
}