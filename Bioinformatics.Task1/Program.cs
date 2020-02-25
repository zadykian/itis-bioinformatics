using System;

namespace Bioinformatics.Task1
{
	internal static class Program
	{
		private static void Main()
		{
			var stringLength = ReadDnaStringLength();
			var percents = ReadGcPercents();
			var randomDnaString = DnaStringGenerator.GetRandomDnaString(stringLength, percents);
			
			Console.WriteLine($"Исходная строка: {randomDnaString}");
			Console.WriteLine($"Фактический GC-состав: {randomDnaString.GetActualGcPercent()}%");

			var maxRnaSequence = randomDnaString.GetMaxRnaSequence();
			
			if (maxRnaSequence.Values.Length < 10)
			{
				Console.WriteLine("ORF не найдена.");
			}
			else
			{
				Console.WriteLine(maxRnaSequence);
				Console.WriteLine(maxRnaSequence.Translate());

				var isReversedString = maxRnaSequence.Reversed ? "обратной" : "прямой";
				Console.WriteLine($"ORF была найдена на {isReversedString} цепи;");
				Console.WriteLine($"Рамка считывания: {maxRnaSequence.ReadingFrame};");
				Console.WriteLine($"Диапазон порядковых номеров: {maxRnaSequence.DnaStringRange}.");
			}

			Console.ReadKey();
		}

		private static ushort ReadDnaStringLength()
		{
			ushort stringLength;
			Console.WriteLine("Введите длину строки ДНК (в диапазоне от 100 до 1000).");
			while (
				!ushort.TryParse(Console.ReadLine(), out stringLength)
				|| stringLength < 100
				|| stringLength > 1000)
			{
				Console.WriteLine("Получена некорректная строка ДНК. Введите снова.");
			}

			return stringLength;
		}

		private static byte ReadGcPercents()
		{
			byte percents;
			Console.WriteLine("Введите GC-состав в процентах (в диапазоне от 20 до 80).");
			while (
				!byte.TryParse(Console.ReadLine(), out percents)
				|| percents < 20
				|| percents > 80)
			{
				Console.WriteLine("Получен некорректный GC-состав. Введите снова.");
			}

			return percents;
		}
	}
}