using System;
using Bioinformatics.Task8.Validation;

namespace Bioinformatics.Task8
{
	internal static class Program
	{
		private static void Main()
		{
			while (true)
			{
				Console.WriteLine("Введите строку - дерево в формате Newick.");
				var newickString = InputReader.ReadValueFromConsole<string>();
				var validationResult = NewickFormatValidator.ValidateNewickString(newickString);

				if (validationResult.IsSuccessful)
				{
					using (ConsoleScope.Info) Console.WriteLine("Строка имеет валидный формат.");
				}
				else
				{
					using (ConsoleScope.Error) Console.WriteLine($"Ошибка валидации: {validationResult.ErrorMessage}");
				}

				Console.WriteLine();
				Console.WriteLine("Произвести валидацию другой строки? y/n");

				var answer = InputReader.ReadValueFromConsole<char>(character 
					=> char.ToLower(character) == 'y' || char.ToLower(character) == 'n');

				if (answer == 'y')
				{
					continue;
				}

				break;
			}
		}
	}
}