using System;
using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	internal static class Program
	{
		private static void Main()
		{
			var strategyType = InputReader.GetAlignmentStrategyType();

			AlignmentResult[] alignmentResults;
			if (strategyType.IsAffine())
			{
				var affineAlignmentStrategy = AlignmentStrategyFactory.CreateAffine(strategyType);
				var inputData = new AlignmentInputData<AffineTransitionWeights>();
				alignmentResults = affineAlignmentStrategy.GetOptimalAlignments(inputData);
			}
			else
			{
				var affineAlignmentStrategy = AlignmentStrategyFactory.Create(strategyType);
				var inputData = new AlignmentInputData<TransitionWeights>();
				alignmentResults = affineAlignmentStrategy.GetOptimalAlignments(inputData);
			}

			Console.WriteLine(alignmentResults);
		}
	}
}