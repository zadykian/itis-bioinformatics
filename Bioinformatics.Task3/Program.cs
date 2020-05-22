using System;
using System.Linq;
using Bioinformatics.Task3.Extensions;

namespace Bioinformatics.Task3
{
	internal static class Program
	{
		private static void Main()
		{
			var strategyType = GetAlignmentStrategyType();
			var alignmentStrategy = (IAlignmentStrategy) Activator.CreateInstance(strategyType);
			
		}

		/// <summary>
		/// Получить тип, реализующий интерфейс <see cref="IAlignmentStrategy"/> в зависимости от выбора пользователя.
		/// </summary>
		private static Type GetAlignmentStrategyType()
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
	}
}