using System.Collections.Generic;
using System.Linq;

namespace Bioinformatics.Task1
{
	internal static class MaxRnaSequenceFinder
	{
		public static RnaSequence GetMaxRnaSequence(DnaString dnaString)
		{
			var maxBuffer = new List<string>();
			ushort startIndex = 0;
			ushort endIndex = 0;

			var currentTokens = dnaString.Value
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

			var dnaStringRange = new DnaStringRange(startIndex, endIndex);
			return new RnaSequence(maxBuffer.ToArray(), dnaString.Reversed, dnaStringRange);
		}
	}
}