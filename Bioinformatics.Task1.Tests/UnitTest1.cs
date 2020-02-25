using NUnit.Framework;

namespace Bioinformatics.Task1.Tests
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			var dnaString = 
				"GGGTTATTATGATGATCGGAGATTTGCCCTGTTCGTTATTGATAACGGGT" +
				"TCACGGACCGAATGCGCCCTCGGCTCAGTACGAACGTTATAACGCGCACC";
			var maxRnaSequence = dnaString.GetMaxRnaSequence();
			
			Assert.AreEqual(
				"atgatgatcggagatttgccctgttcgttattgataacgggttcacggaccgaatgcgccctcggctcagtacgaacgttataa",
				string.Join(string.Empty, maxRnaSequence.Values).ToLower());
			
			Assert.IsFalse(maxRnaSequence.Reversed);
			
			Assert.AreEqual(9, maxRnaSequence.DnaStringRange.FirstCharIndex);
			Assert.AreEqual(92, maxRnaSequence.DnaStringRange.LastCharIndex);
		}
	}
}