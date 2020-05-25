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
		public static ValidationResult Success => new ValidationResult(true, null);

		/// <summary>
		/// Ошибка валидации: отсутствие ';' в конце строки.
		/// </summary>
		public static ValidationResult InvalidEndSymbol => Failure("Некорректный завершающий символ.");

		/// <summary>
		/// Ошибка валидации: несбалансированность скобок.
		/// </summary>
		public static ValidationResult ImbalancedBrackets => Failure("Несбалансированность скобок.");

		/// <summary>
		/// Ошибка валидации: некорректное наименование узла.
		/// </summary>
		public static ValidationResult InvalidNodeName => Failure("Некорректное наименование узла.");

		/// <summary>
		/// Ошибка валидации: дублировано наименование узла.
		/// </summary>
		public static ValidationResult NodeNameDuplicate => Failure("Дублировано наименование узла.");

		/// <summary>
		/// Неудачный результат валидации. 
		/// </summary>
		private static ValidationResult Failure(string errorMessage) => new ValidationResult(false, errorMessage);
	}
}