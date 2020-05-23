using Bio.Algorithms.Alignment;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска глобального выравнивания.
	/// </summary>
	internal class GlobalAlignmentStrategy : AlignmentStrategyBase
	{
		/// <inheritdoc/>
		protected override IPairwiseSequenceAligner GetAligner(in AlignmentInputData alignmentInputData)
		{
			return new NeedlemanWunschAligner
			{
				GapOpenCost = alignmentInputData.TransitionWeights.IndelPenalty
			};
		}
	}
}