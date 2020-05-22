using System;
using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	internal static class Program
	{
		private static void Main()
		{
			var strategyType = InputReader.GetAlignmentStrategyType();
			var alignmentStrategy = AlignmentStrategyFactory.Create(strategyType);
			var alignmentInputData = InputReader.GetAlignmentInputData(strategyType.IsAffine());

			var alignmentResults = alignmentStrategy.GetOptimalAlignments(alignmentInputData);
			Console.WriteLine(alignmentResults);
		}
	}
}