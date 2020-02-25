namespace Bioinformatics.Task1.Tests
{
	public readonly struct TestCaseDto
	{
		public TestCaseDto(string dnaString, 
			string maxRnaSequence, 
			bool reversed, 
			DnaStringRange dnaStringRange)
		{
			DnaString = dnaString;
			MaxRnaSequence = maxRnaSequence;
			Reversed = reversed;
			DnaStringRange = dnaStringRange;
		}

		public string DnaString { get; }
		
		public string MaxRnaSequence { get; }
		
		public bool Reversed { get; }

		public DnaStringRange DnaStringRange { get; }
	}
}