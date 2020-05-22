namespace Bioinformatics.Task3
{
	/// <summary>
	/// Стратегия поиска локального выравнивания с аффинным штрафом.
	/// </summary>
	internal class LocalAffineAlignmentStrategy : IAlignmentStrategy<AffineTransitionWeights>
	{
		/// <inheritdoc/>
		public AlignmentResult[] GetOptimalAlignments(AlignmentInputData<AffineTransitionWeights> inputData)
		{
			throw new System.NotImplementedException();
		}
	}
}