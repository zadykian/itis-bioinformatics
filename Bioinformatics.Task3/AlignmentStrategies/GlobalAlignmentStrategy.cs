using System;
using System.IO;
using System.Reflection;
using Bio;
using Bio.Algorithms.Alignment;
using Bio.SimilarityMatrices;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска глобального выравнивания.
	/// </summary>
	internal class GlobalAlignmentStrategy : IAlignmentStrategy
	{
		/// <inheritdoc/>
		public AlignmentResult[] GetOptimalAlignments(in AlignmentInputData alignmentInputData)
		{
			var leftSequence = new Sequence(Alphabets.DNA, alignmentInputData.FirstDnaString);
			var rightSequence = new Sequence(Alphabets.DNA, alignmentInputData.SecondDnaString);
			var aligner = new NeedlemanWunschAligner();

			var similarityMatrixString = GetSimilarityMatrixString(
				alignmentInputData.TransitionWeights.MatchBonus,
				alignmentInputData.TransitionWeights.MismatchPenalty);

			using var textReader = new StringReader(similarityMatrixString);
			aligner.SimilarityMatrix = new SimilarityMatrix(textReader);
			
			var result = aligner.AlignSimple(leftSequence, rightSequence);

			return null;
		}

		/// <summary>
		/// Загрузить из ресурсов сборки матрицу замен нуклеотидов в строковом представлении.
		/// </summary>
		private static string GetSimilarityMatrixString(ushort matchBonus, short mismatchPenalty)
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
				.Replace("$bonus", matchBonus.ToString())
				.Replace("$penalty", mismatchPenalty.ToString());
		}
	}
}