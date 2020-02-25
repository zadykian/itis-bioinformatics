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
			ushort currentEndIndex = 0;
			
			var rnaSequenceIsFound = false;

			foreach (var currentToken in tokens)
			{
				if (!rnaSequenceIsFound)
				{
					if (currentToken == "ATG")
					{
						rnaSequenceIsFound = true;
						startIndex = currentStartIndex;
						currentBuffer.Add(currentToken);
					}

					currentStartIndex += 3;
					continue;
				}

				if (currentToken == "TGG")
				{
					currentBuffer.Clear();
					rnaSequenceIsFound = false;
				}
			}
			
			
			
			
			// for (ushort i = 0; i < tokens.Length; i++)
			// {
			// 	var currentToken = tokens[i];
			//
			// 	if (!rnaSequenceIsFound)
			// 	{
			// 		if (currentToken == "ATG")
			// 		{
			// 			rnaSequenceIsFound = true;
			// 			currentStartIndex = indexToShow;
			// 			buffer.Add(currentToken);
			// 		}
			// 		indexToShow += 3;
			// 		continue;
			// 	}
			//
			// 	if (currentToken == "TGG")
			// 	{
			// 		buffer.Clear();
			// 		break;
			// 	}
			//
			// 	if (currentToken == "TAA" || currentToken == "TAG" || currentToken == "TGA")
			// 	{
			// 		buffer.Add(currentToken);
			// 		
			// 		if (maxBuffer.Count < buffer.Count)
			// 		{
			// 			indexToShow += 3;
			// 			endIndex = indexToShow;
			// 			startIndex = currentStartIndex;
			// 			maxBuffer = new List<string>(buffer);
			// 		}
			//
			// 		buffer.Clear();
			// 		break;
			// 	}
			// 	
			// 	indexToShow += 3;
			// 	buffer.Add(currentToken);
			// }

			var dnaStringRange = new DnaStringRange(startIndex, endIndex);
			return new RnaSequence(maxBuffer.ToArray(), dnaString.Reversed, dnaStringRange);
		}
	}
}