using System;
using System.Collections.Generic;
using System.Linq;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Класс для отображения результатов в терминале.
	/// </summary>
	internal static class OutputWriter
	{
		/// <summary>
		/// Отобразить в терминале результаты выравнивания. 
		/// </summary>
		public static void DisplayAlignmentResults(IEnumerable<AlignmentResult> alignmentResults)
		{
			ResultHeader("# Полученные результаты #");
			Console.WriteLine();

			foreach (var alignmentResult in alignmentResults)
			{
				ResultHeader("Строковое представление");
				PrintResultString(alignmentResult.AlignedStrings.FirstString, alignmentResult.AlignedStrings.DiffIndices);
				PrintResultString(alignmentResult.AlignedStrings.SecondString, alignmentResult.AlignedStrings.DiffIndices);

				ResultHeader("Значение весовой функции");
				Console.WriteLine(alignmentResult.Score);

				ResultHeader("Количество замен");
				Console.WriteLine(alignmentResult.ReplacementCount);

				ResultHeader("Суммарное количество вставок и делеций");
				Console.WriteLine(alignmentResult.IndelCount);

				Console.WriteLine();
				Console.WriteLine("# # # # # # # #");
				Console.WriteLine();
			}
		}

		private static void PrintResultString(string alignedString, uint[] diffIndices)
		{
			for (var index = 0; index < alignedString.Length; index++)
			{
				var consoleScope = diffIndices.Contains((uint) index)
					? new ConsoleScope(ConsoleColor.DarkYellow, ConsoleColor.Black)
					: ConsoleScope.Default;

				using (consoleScope)
				{
					Console.Write(alignedString[index]);
				}
			}
			
			Console.WriteLine();
		}

		private static void ResultHeader(string message)
		{
			using (ConsoleScope.ResultHeader) Console.WriteLine(message);
		}
	}
}