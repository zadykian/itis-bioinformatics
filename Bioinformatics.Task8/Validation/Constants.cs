namespace Bioinformatics.Task8.Validation
{
	/// <summary>
	/// Константы newick-формата.
	/// </summary>
	internal static class Constants
	{
		/// <summary>
		/// Символ завершения newick-строки.
		/// </summary>
		public const char EndSymbol = ';';

		/// <summary>
		/// Символ - разделитель узлов.
		/// </summary>
		public const char NodeSeparator = ',';

		/// <summary>
		/// Символ - разделитель имени и веса узла дерева.
		/// </summary>
		public const char NameWeightSeparator = ':';
	}
}