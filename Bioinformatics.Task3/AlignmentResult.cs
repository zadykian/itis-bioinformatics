namespace Bioinformatics.Task3
{
	/// <summary>
	/// Результат выравнивания.
	/// </summary>
	internal readonly struct AlignmentResult
	{
		public AlignmentResult(string stringRepresentation, 
			uint totalCost, 
			uint replacementCount, 
			uint indelCount)
		{
			StringRepresentation = stringRepresentation;
			TotalCost = totalCost;
			ReplacementCount = replacementCount;
			IndelCount = indelCount;
		}

		/// <summary>
		/// Строковое представление выравнивания в подстрочном виде.
		/// </summary>
		public string StringRepresentation { get; }

		/// <summary>
		/// Общая стоимость выравнивания (значение весовой функции).
		/// </summary>
		public uint TotalCost { get; }

		/// <summary>
		/// Количество замен.
		/// </summary>
		public uint ReplacementCount { get; }

		/// <summary>
		/// Суммарное количество вставок и делеций.
		/// </summary>
		public uint IndelCount { get; }
	}
}