using System.Collections.Generic;
using NUnit.Framework;

namespace Bioinformatics.Task1.Tests
{
	public class RnaSequenceTests
	{
		[Test]
		[TestCaseSource(nameof(GetTestCaseObjects))]
		public void TestMaxRnaSequenceSearch(TestCaseDto testCaseDto)
		{
			var maxRnaSequence = testCaseDto.DnaString.GetMaxRnaSequence();
			
			Assert.AreEqual(testCaseDto.MaxRnaSequence,
				string.Join(string.Empty, maxRnaSequence.Values).ToLower());
			
			Assert.AreEqual(testCaseDto.Reversed, maxRnaSequence.Reversed);
			Assert.AreEqual(testCaseDto.DnaStringRange, maxRnaSequence.DnaStringRange);
		}

		private static IEnumerable<TestCaseDto> GetTestCaseObjects()
		{
			yield return new TestCaseDto(
				"GGGTTATTATGATGATCGGAGATTTGCCCTGTTCGTTATTGATAACGGGTTCACGGACCGAATGCGCCCTCGGCTCAGTACGAACGTTATAACGCGCACC",
				"atgatgatcggagatttgccctgttcgttattgataacgggttcacggaccgaatgcgccctcggctcagtacgaacgttataa",
				false,
				new DnaStringRange(9, 92));
			
			yield return new TestCaseDto(
				"GCTCTTCGCGAAAGGAGCGAACCACATGCCTGCGGAGGTCGAACACACCGACGCCTCTGTCCAGGACATCTTGGACCCTATTGGACTGTGACTTCGGCCTAA" +
				"CATTAAGGCAGCCATAGATCGTCTCTCGACAACACGGCCTAACCACTCCTGGCCACCGAAAAAGTCAAAATGCCTTCACAAAACGAGGTTGAAGTCACGTTCCG" +
				"CGTAATTAAATCGCGAATGGGTGCTCGATCGTGCGCAAGTTTTTAAGATCCTGCGCGCCGTCTGAGAATGTCCTTTCATTGTGCAAGTGACTGC",
				"atgccttcacaaaacgaggttgaagtcacgttccgcgtaattaaatcgcgaatgggtgctcgatcgtgcgcaagtttttaa",
				false,
				new DnaStringRange(172, 252));
		}
	}
}