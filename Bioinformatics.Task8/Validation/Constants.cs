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

		/// <summary>
		/// Символы, недопустимые в составе веса узла (помимо буквенных символов). 
		/// </summary>
		public static readonly char[] InvalidWeightChars = {';', ':', ' ', '(', ')'};

		/// <summary>
		/// Символы, недопустимые в составе наименования узла.
		/// </summary>
		public static readonly char[] InvalidNodeChars = {';', ' ', '('};
	}
}