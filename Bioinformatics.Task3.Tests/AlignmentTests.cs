using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bioinformatics.Task3.Tests
{
	/// <summary>
	/// Тесты стратегий выравнивания.
	/// </summary>
	[TestFixture]
	public class AlignmentTests
	{
		[Test]
		[TestCaseSource(nameof(GetTestCases))]
		public void GlobalAlignmentTest(TestCaseDto testCaseDto)
		{
			var alignmentStrategy = new GlobalAlignmentStrategy();
			var alignmentResult = alignmentStrategy.GetOptimalAlignments(testCaseDto.InputData);
			Assert.IsTrue(alignmentResult.SequenceEqual(testCaseDto.Result));
		}

		private static IEnumerable<TestCaseDto> GetTestCases()
		{
			yield return new TestCaseDto
			{
				InputData = new AlignmentInputData(
					"AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGCTTCTGAACTGGTTACCTGCCGTGAGTAAATTAAAATTTTATTGACTTAGG",
					"AAGCTCTTTCATTCTGACTGCAACGGGCAATATTCCCTGTGTGGATTAAAAAAAGAGTGTCTGATGAGCAGCTTCTGAACTGGTTACCTGCCGAATGAGTAAATTAATATTTTATTGACTTAGG",
					new TransitionWeights(5, -4, -5)),

				Result = new[]
				{
					new AlignmentResult(
						new AlignedStrings(
							"A-GCT-TTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGAT-AGCAGCTTCTGAACTGGTTACCTGCCG--TGAGTAAATTAAAATTTTATTGACTTAGG",
							"AAGCTCTTTCATTCTGACTGCAACGGGCAATAT-TCCCTGTGTGGATTAAAAAAAGAGTGTCTGATGAGCAGCTTCTGAACTGGTTACCTGCCGAATGAGTAAATTAATATTTTATTGACTTAGG",
							new uint[]{}), 
						547, 2, 6) 
				}
			};
		}
	}
}