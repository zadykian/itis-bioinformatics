namespace Bioinformatics.Task1
{
	internal readonly struct RnaSequence
	{
		public RnaSequence(string[] values, 
			bool reversed, 
			DnaStringRange dnaStringRange)
		{
			Values = values;
			Reversed = reversed;
			DnaStringRange = dnaStringRange;
		}

		public string[] Values { get; }
		
		public bool Reversed { get; }
		
		public DnaStringRange DnaStringRange { get; }

		public override string ToString() => string.Join(' ', Values);
	}
}