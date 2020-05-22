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
		public static StrategyType GetAlignmentStrategyType()
		{
			var strategyTypesString = Enum
				.GetValues(typeof(StrategyType))
				.Cast<StrategyType>()
				.Select(type => $"{(byte) type} - {type.GetDescription()}")
				.JoinBy(Environment.NewLine);

			using (ConsoleScope.Info) Console.WriteLine("Выберите тип алгоритма:");
			Console.WriteLine(strategyTypesString);
			return ReadValueFromConsole<StrategyType>(value => value.DoNotHaveMultipleFlags());
		}

		/// <summary>
		/// Получить входные параметры выравнивания. 
		/// </summary>
		public static AlignmentInputData GetAlignmentInputData(bool withAffinePenalties)
		{
			Info("Введите первую строку ДНК:");
			var firstDnaString = ReadValueFromConsole<string>(dnaString => dnaString.IsValidDnaString());

			Info("Введите вторую строку ДНК:");
			var secondDnaString = ReadValueFromConsole<string>(dnaString => dnaString.IsValidDnaString());

			Info("Введите размер бонуса за совпадение (строго положительный):");
			var matchBonus = ReadValueFromConsole<ushort>(value => value > 0);

			Info("Введите размер штрафа за несовпадение (строго отрицательный):");
			var mismatchPenalty = ReadValueFromConsole<short>(value => value < 0);

			Info("Введите размер штрафа за вставку или делецию (строго отрицательный):");
			var indelPenalty = ReadValueFromConsole<short>(value => value < 0);

			short? gapOpeningPenalty = null;
			if (withAffinePenalties)
			{
				Info("Введите размер штрафа за открытие гэпа (строго отрицательный):");
				gapOpeningPenalty = ReadValueFromConsole<short>(value => value < 0);
			}

			var transitionWeights = new TransitionWeights(matchBonus, mismatchPenalty, indelPenalty, gapOpeningPenalty);
			return new AlignmentInputData(firstDnaString, secondDnaString, transitionWeights);
		}
		
		/// <summary>
		/// Прочитать значение из терминала.
		/// </summary>
		private static T ReadValueFromConsole<T>(Func<T, bool> validationFunc)
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

		private static void Info(string message)
		{
			using (ConsoleScope.Info) Console.WriteLine(message);
		}

		private static void Error(string message)
		{
			using (ConsoleScope.Error) Console.WriteLine(message);
		}
	}
}