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
				string.Concat(maxRnaSequence.Values).ToLower());
			
			Assert.AreEqual(testCaseDto.Reversed, maxRnaSequence.Reversed);
			Assert.AreEqual(testCaseDto.DnaStringRange, maxRnaSequence.DnaStringRange);
		}

		[Test]
		public void DnaStringWithBiasTest()
		{
			var dnaString = new DnaString(
				"GTTATTATGATGATCGGAGATTTGCCCTGTTCGTTATTGATAACGGGTTCACGGACCGAATGCGCCCTCGGCTCAGTACGAACGTTATAACGCGCACCGG", 
				false, 
				2);

			var rnaSequence = MaxRnaSequenceFinder.GetMaxRnaSequence(dnaString);

			Assert.AreEqual(
				"atgatgatcggagatttgccctgttcgttattgataacgggttcacggaccgaatgcgccctcggctcagtacgaacgttataa",
				string.Concat(rnaSequence.Values).ToLower());
			
			Assert.AreEqual(false, rnaSequence.Reversed);
			Assert.AreEqual(new DnaStringRange(9 , 92), rnaSequence.DnaStringRange);
		}

		[Test]
		public void DnaStringWithTggTest()
		{
			var dnaString = new DnaString(
				string.Concat("ATG", "ATT", "TGG",  "ATC", "GGG", "ATG", "GTA" + "TGC" + "TAG"),
				false);

			var rnaSequence = MaxRnaSequenceFinder.GetMaxRnaSequence(dnaString);

			Assert.AreEqual(
				string.Concat("ATG", "GTA" + "TGC" + "TAG"),
				string.Concat(rnaSequence.Values));
			
			Assert.AreEqual(false, rnaSequence.Reversed);
			Assert.AreEqual(new DnaStringRange(16 , 27), rnaSequence.DnaStringRange);
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