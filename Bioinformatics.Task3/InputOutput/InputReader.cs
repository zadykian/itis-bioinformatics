using System;
using System.Linq;
using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Класс для считывания значений из потока ввода.
	/// </summary>
	internal static class InputReader
	{
		/// <summary>
		/// Получить тип, реализующий интерфейс <see cref="IAlignmentStrategy"/> в зависимости от выбора пользователя.
		/// </summary>
		public static Type GetAlignmentStrategyType()
		{
			var strategyTypesString = Enum
				.GetValues(typeof(StrategyType))
				.Cast<StrategyType>()
				.Select(type => $"{(byte) type} - {type.GetDescription()}")
				.JoinBy(Environment.NewLine);

			Console.WriteLine("Выберите тип алгоритма:");
			Console.WriteLine(strategyTypesString);
			var strategyType = InputReader.ReadValueFromConsole<StrategyType>(value => value.DoNotHaveMultipleFlags());

			return strategyType switch
			{
				StrategyType.GlobalAlignment => typeof(GlobalAlignmentStrategy),
				StrategyType.LocalAlignment => typeof(LocalAlignmentStrategy),
				StrategyType.GlobalAffineAlignment => typeof(GlobalAffineAlignmentStrategy),
				StrategyType.LocalAffineAlignment => typeof(LocalAffineAlignmentStrategy),
				_ => throw new ArgumentOutOfRangeException(nameof(StrategyType))
			};
		}
		
		/// <summary>
		/// Прочитать значение из терминала.
		/// </summary>
		private static T ReadValueFromConsole<T>(Func<T, bool> validationFunc)
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