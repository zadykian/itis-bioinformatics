using System;

namespace Bioinformatics.Task8
{
	/// <summary>
	/// Класс для считывания значений из потока ввода.
	/// </summary>
	internal static class InputReader
	{
		/// <summary>
		/// Прочитать значение из терминала.
		/// </summary>
		public static T ReadValueFromConsole<T>(Func<T, bool> validationFunc = null)
		{
			var actualType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

			while (true)
			{
				string inputValue;
				using (ConsoleScope.Input) inputValue = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(inputValue))
				{
					Error("Получена пустая строка. Попробуйте ещё раз.");
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
					Error("Получено некорректное значение. попробуйте ещё раз.");
					continue;
				}

				if (validationFunc == null || validationFunc(convertedValue))
				{
					Console.WriteLine();
					return convertedValue;
				}

				Error("Получено некорректное значение. попробуйте ещё раз.");
			}
		}

		private static void Error(string message)
		{
			using (ConsoleScope.Error) Console.WriteLine(message);
		}
	}
}