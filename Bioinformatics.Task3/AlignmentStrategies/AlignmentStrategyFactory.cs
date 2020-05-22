using System;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Фабрика создания стратегий выравнивания.
	/// </summary>
	internal static class AlignmentStrategyFactory
	{
		/// <summary>
		/// Создать экземпляр стратегии исходя из типа <paramref name="strategyType"/>. 
		/// </summary>
		public static IAlignmentStrategy Create(StrategyType strategyType)
		{
			var objectType = strategyType switch
			{
				StrategyType.GlobalAlignment => typeof(GlobalAlignmentStrategy),
				StrategyType.LocalAlignment => typeof(LocalAlignmentStrategy),
				_ => throw new ArgumentOutOfRangeException(nameof(StrategyType))
			};

			return (IAlignmentStrategy) Activator.CreateInstance(objectType);
		}

		/// <summary>
		/// Создать экземпляр стратегии исходя из типа <paramref name="strategyType"/>. 
		/// </summary>
		public static IAffineAlignmentStrategy CreateAffine(StrategyType strategyType)
		{
			var objectType = strategyType switch
			{
				StrategyType.GlobalAffineAlignment => typeof(GlobalAffineAlignmentStrategy),
				StrategyType.LocalAffineAlignment => typeof(LocalAffineAlignmentStrategy),
				_ => throw new ArgumentOutOfRangeException(nameof(StrategyType))
			};

			return (IAffineAlignmentStrategy) Activator.CreateInstance(objectType);
		}
	}
}