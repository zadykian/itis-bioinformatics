namespace Bioinformatics.Task3
{
	/// <summary>
	/// Базовый класс стратегии выравнивания.
	/// </summary>
	internal abstract class AlignmentStrategyBase
	{
		protected AlignmentStrategyBase(AlignmentInputData inputData)
		{
			InputData = inputData;
		}

		/// <summary>
		/// Входные данные для выравнивания.
		/// </summary>
		protected AlignmentInputData InputData { get; }
	}
}