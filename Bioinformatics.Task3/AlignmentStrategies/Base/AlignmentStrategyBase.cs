using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Bio;
using Bio.Algorithms.Alignment;
using Bio.SimilarityMatrices;
using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	internal abstract class AlignmentStrategyBase : IAlignmentStrategy
	{
		/// <inheritdoc/>
		public AlignmentResult[] GetOptimalAlignments(in AlignmentInputData alignmentInputData)
		{
			var leftSequence = new Sequence(Alphabets.DNA, alignmentInputData.FirstDnaString);
			var rightSequence = new Sequence(Alphabets.DNA, alignmentInputData.SecondDnaString);
			var aligner = GetAligner(in alignmentInputData);

			var similarityMatrixString = GetSimilarityMatrixString(alignmentInputData.TransitionWeights);
			using var textReader = new StringReader(similarityMatrixString);
			aligner.SimilarityMatrix = new SimilarityMatrix(textReader);
			aligner.GapExtensionCost = alignmentInputData.TransitionWeights.IndelPenalty;

			return aligner
				.AlignSimple(leftSequence, rightSequence)
				.SelectMany(alignment => alignment.PairwiseAlignedSequences)
				.MaxBy(sequence => sequence.GetScore())
				.Select(alignedSequence => alignedSequence.ToAlignmentResult())
				.ToArray();
		}

		/// <summary>
		/// Получить необходимую реализацию <see cref="IPairwiseSequenceAligner"/>.
		/// </summary>
		protected abstract IPairwiseSequenceAligner GetAligner(in AlignmentInputData alignmentInputData);

		/// <summary>
		/// Загрузить из ресурсов сборки матрицу замен нуклеотидов в строковом представлении.
		/// </summary>
		private static string GetSimilarityMatrixString(TransitionWeights transitionWeights)
		{
			using var resourceStream = Assembly
				.GetExecutingAssembly()
				.GetManifestResourceStream($"{typeof(IAlignmentStrategy).Namespace}.Resources.similarity_matrix.txt");

			if (resourceStream == null)
			{
				throw new ApplicationException();
			}

			using var streamReader = new StreamReader(resourceStream);

			return streamReader
				.ReadToEnd()
				.Replace("$match_bonus", transitionWeights.MatchBonus.ToString())
				.Replace("$mismatch_penalty", transitionWeights.MismatchPenalty.ToString())
				.Replace("$indel_penalty", transitionWeights.IndelPenalty.ToString());
		}
	}
}