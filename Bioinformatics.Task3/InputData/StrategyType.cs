using System.ComponentModel;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Тип стратегии выравнивания.
	/// </summary>
	internal enum StrategyType : byte
	{
		/// <summary>
		/// Глобальное выравнивание.
		/// </summary>
		[Description("Глобальное выравнивание.")]
		GlobalAlignment = 1,

		/// <summary>
		/// Локальное выравнивание.
		/// </summary>
		[Description("Локальное выравнивание.")]
		LocalAlignment = 2,

		/// <summary>
		/// Глобальное выравнивание с аффинным штрафом.
		/// </summary>
		[Description("Глобальное выравнивание с аффинным штрафом.")]
		GlobalAffineAlignment = 3,

		/// <summary>
		/// Локальное выравнивание с аффинным штрафом.
		/// </summary>
		[Description("Локальное выравнивание с аффинным штрафом.")]
		LocalAffineAlignment = 4
	}
}