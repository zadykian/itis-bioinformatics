namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска глобального выравнивания с аффинным штрафом.
	/// </summary>
	internal class GlobalAffineAlignmentStrategy : AlignmentStrategyBase, IAlignmentStrategy
	{
		public GlobalAffineAlignmentStrategy(AlignmentInputData inputData) : base(inputData)
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