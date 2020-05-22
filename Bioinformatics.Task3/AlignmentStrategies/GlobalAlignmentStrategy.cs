namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска глобального выравнивания.
	/// </summary>
	internal class GlobalAlignmentStrategy : AlignmentStrategyBase, IAlignmentStrategy
	{
		public GlobalAlignmentStrategy(AlignmentInputData inputData) : base(inputData)
		{
		}

		/// <inheritdoc/>
		public AlignmentResult[] GetOptimalAlignments(in AlignmentInputData alignmentInputData)
		{
			System.Console.WriteLine($"{GetType()} is not implemented!");
			System.Console.ReadKey();
			return null;
		}
	}
}