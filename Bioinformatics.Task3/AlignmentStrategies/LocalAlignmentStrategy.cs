namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска локального выравнивания.
	/// </summary>
	internal class LocalAlignmentStrategy : AlignmentStrategyBase, IAlignmentStrategy
	{
		public LocalAlignmentStrategy(AlignmentInputData inputData) : base(inputData)
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