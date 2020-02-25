namespace Bioinformatics.Task1
{
	public readonly struct DnaStringRange
	{
		public DnaStringRange(ushort firstCharIndex, ushort lastCharIndex)
		{
			FirstCharIndex = firstCharIndex;
			LastCharIndex = lastCharIndex;
		}

		public ushort FirstCharIndex { get; }
		
		public ushort LastCharIndex { get; }

		public override string ToString() => $"[{FirstCharIndex}, {LastCharIndex}]";

		public static DnaStringRange operator +(DnaStringRange dnaStringRange, byte bias)
		{
			var firstCharIndex = (ushort) (dnaStringRange.FirstCharIndex + bias);
			var lastCharIndex = (ushort) (dnaStringRange.LastCharIndex + bias);
			return new DnaStringRange(firstCharIndex, lastCharIndex);
		}
		
		public static DnaStringRange operator -(DnaStringRange dnaStringRange, byte bias)
		{
			var firstCharIndex = (ushort) (dnaStringRange.FirstCharIndex - bias);
			var lastCharIndex = (ushort) (dnaStringRange.LastCharIndex - bias);
			return new DnaStringRange(firstCharIndex, lastCharIndex);
		}
	}
}