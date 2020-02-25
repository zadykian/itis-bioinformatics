using System.Linq;

namespace Bioinformatics.Task1
{
	public static class PublicStringExtensions
	{
		public static RnaSequence GetMaxRnaSequence(this string randomDnaString)
		{
			return randomDnaString
				.GetDnaStrings()
				.Select(MaxRnaSequenceFinder.GetMaxRnaSequence)
				.OrderByDescending(rnaSequence => rnaSequence.Values.Length)
				.First();
		}
	}
}