using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	internal static class Program
	{
		private static void Main()
		{
			var strategyType = InputReader.GetAlignmentStrategyType();
			var alignmentInputData = InputReader.GetAlignmentInputData(strategyType.IsAffine());
			var alignmentStrategy = AlignmentStrategyFactory.Create(strategyType, alignmentInputData);

			var alignmentResults = alignmentStrategy.GetOptimalAlignments(alignmentInputData);
			OutputWriter.DisplayAlignmentResults(alignmentResults);
		}
	}
}