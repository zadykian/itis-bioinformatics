namespace Bioinformatics.Task1
{
	internal readonly struct DnaString
	{
		public DnaString(string value, bool reversed, byte readingFrame)
		{
			Value = value;
			Reversed = reversed;
			ReadingFrame = readingFrame;
		}

		public string Value { get; }
		
		public bool Reversed { get; }
		
		public byte ReadingFrame { get; }
	}
}