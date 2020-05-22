namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска оптимальных выравниваний.
	/// </summary>
	internal interface IAlignmentStrategy
	{
		/// <summary>
		/// Найти все оптимальные выравнивания последовательностей ДНК.
		/// </summary>
		AlignmentResult[] GetOptimalAlignments(in AlignmentInputData alignmentInputData);
	}
}