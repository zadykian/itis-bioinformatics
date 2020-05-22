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
		public static IAlignmentStrategy Create(in StrategyType strategyType)
		{
			var objectType = strategyType switch
			{
				StrategyType.GlobalAlignment => typeof(GlobalAlignmentStrategy),
				StrategyType.LocalAlignment => typeof(LocalAlignmentStrategy),
				StrategyType.GlobalAffineAlignment => typeof(GlobalAffineAlignmentStrategy),
				StrategyType.LocalAffineAlignment => typeof(LocalAffineAlignmentStrategy),
				_ => throw new ArgumentOutOfRangeException(nameof(StrategyType))
			};

			return (IAlignmentStrategy) Activator.CreateInstance(objectType);
		}
	}
}