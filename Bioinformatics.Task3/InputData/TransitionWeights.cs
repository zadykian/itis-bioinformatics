namespace Bioinformatics.Task3
{
	/// <summary>
	/// Веса переходных операций выравнивания.
	/// </summary>
	internal readonly struct TransitionWeights
	{
		public TransitionWeights(ushort matchBonus,
			short mismatchPenalty,
			short indelPenalty,
			short? gapOpeningPenalty = null)
		{
			MatchBonus = matchBonus;
			MismatchPenalty = mismatchPenalty;
			IndelPenalty = indelPenalty;
			GapOpeningPenalty = gapOpeningPenalty;
		}

		/// <summary>
		/// Бонус за совпадение (строго положительный).
		/// </summary>
		public ushort MatchBonus { get; }

		/// <summary>
		/// Штраф за несовпадение (строго отрицательный).
		/// </summary>
		public short MismatchPenalty { get; }
		
		/// <summary>
		/// Штраф за вставку или делецию (строго отрицательный).
		/// </summary>
		public short IndelPenalty { get; }

		/// <summary>
		/// Штраф за открытие гэпа (строго отрицательный).
		/// </summary>
		public short? GapOpeningPenalty { get; }
	}
}