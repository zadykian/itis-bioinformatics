namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска оптимальных выравниваний.
	/// </summary>
	internal interface IAlignmentStrategy<TWeights>
		where TWeights : TransitionWeights
	{
		/// <summary>
		/// Найти все оптимальные выравнивания последовательностей ДНК.
		/// </summary>
		AlignmentResult[] GetOptimalAlignments(AlignmentInputData<TWeights> inputData);
	}
}