namespace Bioinformatics.Task1.Tests
{
	public readonly struct TestCaseDto
	{
		public TestCaseDto(string dnaString, 
			string maxRnaSequence, 
			bool reversed, 
			DnaStringRange dnaStringRange, byte readingFrame)
		{
			DnaString = dnaString;
			MaxRnaSequence = maxRnaSequence;
			Reversed = reversed;
			DnaStringRange = dnaStringRange;
			ReadingFrame = readingFrame;
		}

		public string DnaString { get; }
		
		public string MaxRnaSequence { get; }
		
		public bool Reversed { get; }

		public DnaStringRange DnaStringRange { get; }
		
		public byte ReadingFrame { get; }
	}
}