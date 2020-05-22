namespace Bioinformatics.Task3
{
	/// <summary>
	/// Веса переходных операций выравнивания с аффинным штрафом.
	/// </summary>
	internal class AffineTransitionWeights : TransitionWeights
	{
		public AffineTransitionWeights(ushort matchBonus, 
			short mismatchPenalty, 
			short indelPenalty, 
			short gapPenalty) 
			: base(matchBonus, mismatchPenalty, indelPenalty)
		{
			GapPenalty = gapPenalty;
		}

		/// <summary>
		/// Штраф за открытие гэпа (строго отрицательный).
		/// </summary>
		public short GapPenalty { get; }
	}
}