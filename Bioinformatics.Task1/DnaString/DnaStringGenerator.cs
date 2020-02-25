using System;
using System.Text;

namespace Bioinformatics.Task1
{
	public static class DnaStringGenerator
	{
		private static readonly Random random = new Random();
		
		public static string GetRandomDnaString(ushort length, byte percents)
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
		
		private static char GetRandomChar(bool withGc)
		{
			var randomValue = random.Next(0, 99);

			if (!withGc)
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
	}
}