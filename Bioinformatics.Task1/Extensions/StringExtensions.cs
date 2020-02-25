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

		public static string Reverse(this string stringValue)
		{
			var chars = stringValue.ToCharArray();
			Array.Reverse(chars);
			return new string(chars);
		}

		public static string FirstCharToEnd(this string stringValue)
		{
			var firstChar = stringValue[0];
			return stringValue.Substring(1, stringValue.Length - 1) + firstChar;
		}
	}
}