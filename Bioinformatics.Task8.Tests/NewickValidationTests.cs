using System.Collections.Generic;
using Bioinformatics.Task8.Validation;
using NUnit.Framework;

namespace Bioinformatics.Task8.Tests
{
	/// <summary>
	/// Тесты валидации Newick-формата.
	/// </summary>
	public class NewickValidationTests
	{
		[Test]
		[TestCaseSource(nameof(GetTestCases))]
		public void ValidateNewickString(TestCaseDto testCaseDto)
		{
			var validationResult = NewickFormatValidator.ValidateNewickString(testCaseDto.NewickString);
			Assert.AreEqual(testCaseDto.IsSuccessful, validationResult.IsSuccessful);
		}

		private static IEnumerable<TestCaseDto> GetTestCases()
		{
			yield return new TestCaseDto("(A:17, (B:31, C:22):25, D:22, (E:33, F:12):40);", true);
			yield return new TestCaseDto("((apple:12, pear:10)fruits:3, (tomato:23, cucumber:19)vegetables:5);", true);
			yield return new TestCaseDto("(cow:20, (gnu:30, buffalo:60):20):50;", true);
			yield return new TestCaseDto("(,,(,));", true);
			yield return new TestCaseDto("(A,B,(C,D));", true);
			yield return new TestCaseDto("(horse1:20, (monkey:30, horse2:60):20):50;", true);

			yield return new TestCaseDto("(horse:20, (mon:key:30, ant:60):20):50", false);
			yield return new TestCaseDto("(bat:17, (ant:31, human:22):25, cat:22, (fox:33, elk:12:40)", false);
			yield return new TestCaseDto("(bat:17, (cat:31, mouse:2 2):25, human:22, (pet:33, F:12):40)", false);
			yield return new TestCaseDto("(A,B,(A,D));", false);
			yield return new TestCaseDto("(horse1:20, (monkey:30, horse1:60):20):50;", false);
		}
	}
}