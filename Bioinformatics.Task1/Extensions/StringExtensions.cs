using System;
using System.Collections.Generic;
using System.Linq;

namespace Bioinformatics.Task1
{
	internal static class StringExtensions
	{
		public static IEnumerable<string> Split(this string str, int chunkSize)
		{
			return Enumerable
				.Range(0, str.Length / chunkSize)
				.Select(i => str.Substring(i * chunkSize, chunkSize));
		}

		public static RnaSequence GetMaxRnaSequence(this string randomDnaString)
		{
			return randomDnaString
				.GetDnaStrings()
				.Select(MaxRnaSequenceFinder.GetMaxRnaSequence)
				.OrderByDescending(rnaSequence => rnaSequence.Values.Length)
				.First();
		}

		private static IEnumerable<DnaString> GetDnaStrings(this string randomDnaString)
		{
			return new[]
			{
				new DnaString(randomDnaString, false),
				new DnaString(randomDnaString.Reverse(), true),

				new DnaString(randomDnaString.FirstCharToEnd(), false, 1),
				new DnaString(randomDnaString.FirstCharToEnd().Reverse(), true, 1),

				new DnaString(randomDnaString.FirstCharToEnd().FirstCharToEnd(), false, 2),
				new DnaString(randomDnaString.FirstCharToEnd().FirstCharToEnd().Reverse(), true, 2)
			};
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
	}
}