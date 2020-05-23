using Bio.Algorithms.Alignment;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска локального выравнивания.
	/// </summary>
	internal class LocalAlignmentStrategy : AlignmentStrategyBase
	{
		/// <inheritdoc/>
		protected override IPairwiseSequenceAligner GetAligner(in AlignmentInputData alignmentInputData)
		{
			return new SmithWatermanAligner
			{
				GapOpenCost = alignmentInputData.TransitionWeights.IndelPenalty
			};
		}
	}
}