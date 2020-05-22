namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типа <see cref="StrategyType"/>.
	/// </summary>
	internal static class StrategyTypeExtensions
	{
		/// <summary>
		/// Является ли стратегия выравнивания аффинной.
		/// </summary>
		public static bool IsAffine(this StrategyType strategyType)
		{
			return
				strategyType == StrategyType.GlobalAffineAlignment
				|| strategyType == StrategyType.LocalAffineAlignment;
		}
	}
}