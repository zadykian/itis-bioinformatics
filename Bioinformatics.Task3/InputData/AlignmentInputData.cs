namespace Bioinformatics.Task3
{
	/// <summary>
	/// Входные данные для выравнивания.
	/// </summary>
	internal readonly struct AlignmentInputData
	{
		public AlignmentInputData(string firstDnaString, string secondDnaString, 
			TransitionWeights transitionWeights)
		{
			FirstDnaString = firstDnaString;
			SecondDnaString = secondDnaString;
			TransitionWeights = transitionWeights;
		}

		/// <summary>
		/// Первая строка ДНК.
		/// </summary>
		public string FirstDnaString { get; }

		/// <summary>
		/// Вторая строка ДНК.
		/// </summary>
		public string SecondDnaString { get; }

		/// <summary>
		/// Веса переходных операций выравнивания.
		/// </summary>
		public TransitionWeights TransitionWeights { get; }
	}
}