using System;
using Bio.Algorithms.Alignment;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска глобального выравнивания с аффинным штрафом.
	/// </summary>
	internal class GlobalAffineAlignmentStrategy : AlignmentStrategyBase
	{
		/// <inheritdoc/>
		protected override IPairwiseSequenceAligner GetAligner(in AlignmentInputData alignmentInputData)
		{
			var gapOpenPenalty = alignmentInputData.TransitionWeights.GapOpeningPenalty;

			if (!gapOpenPenalty.HasValue)
			{
				throw new ArgumentNullException(nameof(TransitionWeights.GapOpeningPenalty));
			}

			return new NeedlemanWunschAligner
			{
				GapOpenCost = gapOpenPenalty.Value
			};
		}
	}
}