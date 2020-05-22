namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска локального выравнивания с аффинным штрафом.
	/// </summary>
	internal class LocalAffineAlignmentStrategy : AlignmentStrategyBase, IAlignmentStrategy
	{
		/// <inheritdoc/>
		public AlignmentResult[] GetOptimalAlignments(in AlignmentInputData alignmentInputData)
		{
			System.Console.WriteLine($"{GetType()} is not implemented!");
			System.Console.ReadKey();
			return null;
		}
	}
}