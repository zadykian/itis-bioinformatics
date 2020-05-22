using System;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Класс для считывания значений из потока ввода.
	/// </summary>
	internal static class InputReader
	{
		/// <summary>
		/// Прочитать значение из терминала.
		/// </summary>
		public static T ReadValueFromConsole<T>(Func<T, bool> validationFunc)
		{
			var actualType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

			while (true)
			{
				var inputValue = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(inputValue))
				{
					using (ConsoleScope.Error()) Console.WriteLine("Получена пустая строка. Попробуйте ещё раз.");
					continue;
				}

				T convertedValue;
				try
				{
					convertedValue = actualType.IsEnum
						? (T) Enum.Parse(typeof(T), inputValue)
						: (T) Convert.ChangeType(inputValue, actualType);
				}
				catch
				{
					using (ConsoleScope.Error()) Console.WriteLine("Получено некорректное значение. попробуйте ещё раз.");
					continue;
				}

				if (validationFunc == null || validationFunc(convertedValue))
				{
					return convertedValue;
				}

				using (ConsoleScope.Error()) Console.WriteLine("Получено некорректное значение. попробуйте ещё раз.");
			}
		}
	}
}