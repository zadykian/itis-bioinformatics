namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска глобального выравнивания.
	/// </summary>
	internal class GlobalAlignmentStrategy : IAlignmentStrategy
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