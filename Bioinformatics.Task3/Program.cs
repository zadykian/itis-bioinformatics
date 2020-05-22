using System;

namespace Bioinformatics.Task3
{
	internal static class Program
	{
		private static void Main()
		{
			var strategyType = InputReader.GetAlignmentStrategyType();
			var alignmentStrategy = (IAlignmentStrategy) Activator.CreateInstance(strategyType);

		}
	}
}