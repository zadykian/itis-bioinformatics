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

			var tokens = dnaString.Value
				.Split(3)
				.ToArray();

			var currentBuffer = new List<string>();
			ushort currentStartIndex = 1;
			ushort currentEndIndex = 3;
			
			var rnaSequenceIsFound = false;

			void Reset()
			{
				currentBuffer.Clear();
				currentStartIndex = (ushort) (currentEndIndex + 1);
				currentEndIndex += 3;
				rnaSequenceIsFound = false;
			}

			foreach (var currentToken in tokens)
			{
				if (!rnaSequenceIsFound)
				{
					if (currentToken == "ATG")
					{
						rnaSequenceIsFound = true;
						currentBuffer.Add(currentToken);
						currentEndIndex += 3;
					}
					else
					{
						currentStartIndex += 3;
						currentEndIndex += 3;
					}
					
					continue;
				}

				if (currentToken == "TGG")
				{
					Reset();
					continue;
				}
				
				currentBuffer.Add(currentToken);

				if (currentToken != "TAA" && currentToken != "TAG" && currentToken != "TGA")
				{
					currentEndIndex += 3;
					continue;
				}
				
				if (maxBuffer.Count < currentBuffer.Count)
				{
					endIndex = currentEndIndex;
					startIndex = currentStartIndex;
					maxBuffer = new List<string>(currentBuffer);
				}
			
				Reset();
			}

			var dnaStringRange = new DnaStringRange(startIndex, endIndex) + (byte) (dnaString.ReadingFrame - 1);
			return new RnaSequence(maxBuffer.ToArray(), dnaString.Reversed, dnaString.ReadingFrame, dnaStringRange);
		}
	}
}