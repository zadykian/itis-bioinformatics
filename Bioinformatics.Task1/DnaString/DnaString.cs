namespace Bioinformatics.Task1
{
	internal readonly struct DnaString
	{
		public DnaString(string value, bool reversed)
		{
			Value = value;
			Reversed = reversed;
		}

		public string Value { get; }
		
		public bool Reversed { get; }
	}
}