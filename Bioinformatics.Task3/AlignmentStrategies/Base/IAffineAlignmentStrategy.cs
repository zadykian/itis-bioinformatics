namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска оптимальных выравниваний c аффинным штрафом.
	/// </summary>
	internal interface IAffineAlignmentStrategy
	{
		/// <summary>
		/// Найти все оптимальные выравнивания последовательностей ДНК.
		/// </summary>
		AlignmentResult[] GetOptimalAlignments(AlignmentInputData<AffineTransitionWeights> inputData);
	}
}