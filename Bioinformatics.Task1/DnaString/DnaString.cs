namespace Bioinformatics.Task1
{
	internal readonly struct DnaString
	{
		public DnaString(string value, bool reversed, byte bias = 0)
		{
			Value = value;
			Reversed = reversed;
			Bias = bias;
		}

		public string Value { get; }
		
		public bool Reversed { get; }
		
		public byte Bias { get; }
	}
}