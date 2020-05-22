using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	internal static class Program
	{
		private static void Main()
		{
			var strategyType = InputReader.GetAlignmentStrategyType();
			var alignmentInputData = InputReader.GetAlignmentInputData(strategyType.IsAffine());
			var alignmentStrategy = AlignmentStrategyFactory.Create(in strategyType);

			var alignmentResults = alignmentStrategy.GetOptimalAlignments(in alignmentInputData);
			OutputWriter.DisplayAlignmentResults(alignmentResults);
			System.Console.ReadKey();
		}
	}
}