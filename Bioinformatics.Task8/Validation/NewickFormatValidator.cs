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
			if (newickString[^1] != Constants.EndSymbol)
			{
				return ValidationResult.InvalidEndSymbol;
			}

			var bracketsCount = 0;

			foreach (var character in newickString)
			{
				switch (character)
				{
					case '(':
					{
						bracketsCount++;
						continue;
					}

					case ')':
					{
						bracketsCount--;
						if (bracketsCount < 0) return ValidationResult.ImbalancedBrackets;
						continue;
					}
				}
			}

			return bracketsCount == 0
				? ValidationResult.Success
				: ValidationResult.ImbalancedBrackets;
		}
	}
}