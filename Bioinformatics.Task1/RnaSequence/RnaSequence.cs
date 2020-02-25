namespace Bioinformatics.Task1
{
	public readonly struct RnaSequence
	{
		public RnaSequence(string[] values, 
			bool reversed, 
			byte readingFrame,
			DnaStringRange dnaStringRange)
		{
			Values = values;
			Reversed = reversed;
			ReadingFrame = readingFrame;
			DnaStringRange = dnaStringRange;
		}

		public string[] Values { get; }
		
		public bool Reversed { get; }
		
		public byte ReadingFrame { get; }
		
		public DnaStringRange DnaStringRange { get; }

		public override string ToString() => string.Join(' ', Values);
	}
}