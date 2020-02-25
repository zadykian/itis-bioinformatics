﻿using System;
using System.Linq;

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

			var strings = new[]
			{
				new DnaString(randomDnaString, false),
				new DnaString(randomDnaString.Reverse(), true),

				new DnaString(randomDnaString.FirstCharToEnd(), false),
				new DnaString(randomDnaString.FirstCharToEnd().Reverse(), true),

				new DnaString(randomDnaString.FirstCharToEnd().FirstCharToEnd(), false),
				new DnaString(randomDnaString.FirstCharToEnd().FirstCharToEnd().Reverse(), true)
			};

			var maxRnaSequence = strings
				.Select(MaxRnaSequenceFinder.GetMaxRnaSequence)
				.OrderByDescending(rnaSequence => rnaSequence.Values.Length)
				.First();
			
			if (maxRnaSequence.Values.Length == 0)
			{
				Console.WriteLine("ORF не найдена.");
			}
			else
			{
				Console.WriteLine(maxRnaSequence);
				Console.WriteLine(maxRnaSequence.Translate());

				var isReversedString = maxRnaSequence.Reversed ? "обратной" : "прямой";
				Console.WriteLine($"ORF была найдена на {isReversedString} цепи.");
				Console.WriteLine($"Диапазон порядковых номеров: {maxRnaSequence.DnaStringRange}");
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