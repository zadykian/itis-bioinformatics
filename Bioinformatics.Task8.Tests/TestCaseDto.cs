namespace Bioinformatics.Task8.Tests
{
	/// <summary>
	/// Объект, представляющий тестового кейс.
	/// </summary>
	public readonly struct TestCaseDto
	{
		internal TestCaseDto(string newickString, bool isSuccessful)
		{
			NewickString = newickString;
			IsSuccessful = isSuccessful;
		}

		/// <summary>
		/// Строка в newick-формате.
		/// </summary>
		internal string NewickString { get; }

		/// <summary>
		/// Валидна ли newick-строка.
		/// </summary>
		internal bool IsSuccessful { get; }
	}
}