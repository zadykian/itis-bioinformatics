namespace Bioinformatics.Task8.Validation
{
	/// <summary>
	/// Результат валидации.
	/// </summary>
	internal readonly struct ValidationResult
	{
		private ValidationResult(bool isSuccessful, string errorMessage)
		{
			IsSuccessful = isSuccessful;
			ErrorMessage = errorMessage;
		}

		/// <summary>
		/// Успешно ли прошла валидация.
		/// </summary>
		public bool IsSuccessful { get; }

		/// <summary>
		/// Сообщение об ошибке валидации.
		/// </summary>
		public string ErrorMessage { get; }

		/// <summary>
		/// Успешный результат валидации. 
		/// </summary>
		public static ValidationResult Success() => new ValidationResult(true, null);

		/// <summary>
		/// Неудачный результат валидации. 
		/// </summary>
		public static ValidationResult Failure(string errorMessage) => new ValidationResult(false, errorMessage);
	}
}