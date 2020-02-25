using System;
using System.Collections.Generic;
using System.Linq;

namespace Bioinformatics.Task1
{
	internal static class InternalStringExtensions
	{
		public static IEnumerable<string> Split(this string str, int chunkSize)
		{
			return Enumerable
				.Range(0, str.Length / chunkSize)
				.Select(i => str.Substring(i * chunkSize, chunkSize));
		}

		public static IEnumerable<DnaString> GetDnaStrings(this string randomDnaString)
		{
			return new[]
			{
				new DnaString(randomDnaString, false, 1),
				new DnaString(randomDnaString.Reverse(), true, 1),

				new DnaString(randomDnaString.FirstCharToEnd(), false, 2),
				new DnaString(randomDnaString.FirstCharToEnd().Reverse(), true, 2),

				new DnaString(randomDnaString.FirstCharToEnd().FirstCharToEnd(), false, 3),
				new DnaString(randomDnaString.FirstCharToEnd().FirstCharToEnd().Reverse(), true, 3)
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

		public static double GetActualGcPercent(this string stringValue)
		{
			var gcCharsCount = stringValue
				.Count(character => character == 'G' || character == 'C');

			return (double) gcCharsCount / stringValue.Length * 100;
		}
	}
}