namespace Bioinformatics.Task8.Validation
{
	/// <summary>
	/// Валидатор формата Newick.
	/// </summary>
	internal static class NewickFormatValidator
	{
		/// <summary>
		/// Произвести валидацию строки в формате Newick.
		/// </summary>
		public static ValidationResult ValidateNewickString(string newickString)
		{
			return ValidationResult.Success();
		}
	}
}