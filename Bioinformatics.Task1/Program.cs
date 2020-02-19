using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioinformatics.Task1
{
	internal static class Program
	{
		private static readonly Random random = new Random();
		
		private static void Main()
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

			byte percents;
			Console.WriteLine("Введите GC-состав в процентах (в диапазоне от 20 до 80).");
			while (
				!byte.TryParse(Console.ReadLine(), out percents)
				|| percents < 20
				|| percents > 80)
			{
				Console.WriteLine("Получен некорректный GC-состав. Введите снова.");
			}

			var randomDnaString = GetRandomDnaString(stringLength, percents);
			Console.WriteLine($"Исходная строка: {randomDnaString}");

			var strings = new[]
			{
				randomDnaString,
				randomDnaString.Reverse(),

				randomDnaString.FirstCharToEnd(),
				randomDnaString.FirstCharToEnd().Reverse(),

				randomDnaString.FirstCharToEnd().FirstCharToEnd(),
				randomDnaString.FirstCharToEnd().FirstCharToEnd().Reverse()
			};

			var (rnaSequence, reversed, startIndex, endIndex) = GetMaxRnaSequence(strings);

			if (rnaSequence.Length == 0)
			{
				Console.WriteLine("ORF не найдена.");
			}
			else
			{
				Console.WriteLine(string.Join(" ", rnaSequence));
				Console.WriteLine(string.Join(" ", rnaSequence.Select(Translate)));

				var txt = reversed ? "обратной" : "прямой";
				Console.WriteLine($"ORF была найдена на {txt} цепи.");
				Console.WriteLine($"Диапазон порядковых номеров: [{startIndex}, {endIndex}]");
			}

			Console.ReadKey();
		}

		private static (string[], bool, ushort, ushort) GetMaxRnaSequence(string[] generatedStrings)
		{
			var maxBuffer = new List<string>();
			var reversed = false;
			ushort startIndex = 0;
			ushort endIndex = 0;
			
			foreach (var stringValue in generatedStrings)
			{
				var currentTokens = stringValue
					.Split(3)
					.ToArray();

				var buffer = new List<string>();
				var flag = false;

				ushort currentStartIndex = 0;
				ushort indexToShow = 1;
				for (ushort i = 0; i < currentTokens.Length; i++)
				{
					var currentToken = currentTokens[i];

					if (!flag)
					{
						if (currentToken == "ATG")
						{
							flag = true;
							currentStartIndex = indexToShow;
							buffer.Add(currentToken);
						}
						indexToShow += 3;
						continue;
					}

					if (currentToken == "TGG")
					{
						buffer.Clear();
						break;
					}

					if (currentToken == "TAA" || currentToken == "TAG" || currentToken == "TGA")
					{
						buffer.Add(currentToken);
						
						if (maxBuffer.Count < buffer.Count)
						{
							indexToShow += 3;
							endIndex = indexToShow;
							startIndex = currentStartIndex;
							maxBuffer = new List<string>(buffer);
						}

						buffer.Clear();
						break;
					}
					
					indexToShow += 3;
					buffer.Add(currentToken);
				}

				reversed = !reversed;
			}

			return (maxBuffer.ToArray(), reversed, startIndex, endIndex);
		}
		
		private static IEnumerable<string> Split(this string str, int chunkSize)
		{
			return Enumerable
				.Range(0, str.Length / chunkSize)
				.Select(i => str.Substring(i * chunkSize, chunkSize));
		}

		private static string Reverse(this string stringValue)
		{
			var chars = stringValue.ToCharArray();
			Array.Reverse(chars);
			return new string(chars);
		}

		private static string FirstCharToEnd(this string stringValue)
		{
			var firstChar = stringValue[0];
			return stringValue.Substring(1, stringValue.Length - 1) + firstChar;
		}

		private static string GetRandomDnaString(ushort length, byte percents)
		{
			var gcCount = length * (double) percents / 100;
			var stringBuilder = new StringBuilder();

			for (var i = 0; i < length; i++)
			{
				var letter = GetRandomChar(true);
				if ((letter == 'C' || letter == 'G') && gcCount > 0)
				{
					stringBuilder.Append(letter);
					gcCount--;
				}
				else
				{
					stringBuilder.Append(GetRandomChar(false));
				}
			}

			return stringBuilder.ToString();
		}

		private static char GetRandomChar(bool withGC)
		{
			var randomValue = random.Next(0, 99);

			if (withGC)
			{
				if (randomValue < 50)
				{
					return 'T';
				}

				return 'A';
			}
			
			if (randomValue < 25)
			{
				return 'T';
			}

			if (randomValue < 50)
			{
				return 'C';
			}

			if (randomValue < 75)
			{
				return 'A';
			}

			return 'G';
		}
		
		private static string Translate(string stringValue)
		{
			return stringValue switch
			{
				"TTT" => "Phe",
				"TTC" => "Phe",
				"TTA" => "Leu",
				"TTG" => "Leu",
				"TCT" => "Ser",
				"TCC" => "Ser",
				"TCA" => "Ser",
				"TCG" => "Ser",
				"TAT" => "Tyr",
				"TAC" => "Tyr",
				"TAA" => "",
				"TAG" => "",
				"TGT" => "Cys",
				"TGC" => "Cys",
				"TGA" => "",
				"TGG" => "",

				"CTT" => "Leu",
				"CTC" => "Leu",
				"CTA" => "Leu",
				"CTG" => "Leu",
				"CCT" => "Pro",
				"CCC" => "Pro",
				"CCA" => "Pro",
				"CCG" => "Pro",
				"CAT" => "His",
				"CAC" => "His",
				"CAA" => "Gln",
				"CAG" => "Gln",
				"CGT" => "Arg",
				"CGC" => "Arg",
				"CGA" => "Arg",
				"CGG" => "Arg",

				"ATT" => "Ile",
				"ATC" => "Ile",
				"ATA" => "Ile",
				"ATG" => "Met",
				"ACT" => "Thr",
				"ACC" => "Thr",
				"ACA" => "Thr",
				"ACG" => "Thr",
				"AAT" => "Asn",
				"AAC" => "Asn",
				"AAA" => "Lys",
				"AAG" => "Lys",
				"AGT" => "Ser",
				"AGC" => "Ser",
				"AGA" => "Arg",
				"AGG" => "Arg", 
				
				"GTT" => "Val",
				"GTC" => "Val",
				"GTA" => "Val",
				"GTG" => "Val",
				"GCT" => "Ala",
				"GCC" => "Ala",
				"GCA" => "Ala",
				"GCG" => "Ala",
				"GAT" => "Asp",
				"GAC" => "Asp",
				"GAA" => "Glu",
				"GAG" => "Glu",
				"GGT" => "Gly",
				"GGC" => "Gly",
				"GGA" => "Gly",
				"GGG" => "Gly",
				_ => ""
			};
		}
	}
}