namespace Bioinformatics.Task1
{
	internal readonly struct DnaStringRange
	{
		public DnaStringRange(ushort firstCharIndex, ushort lastCharIndex)
		{
			FirstCharIndex = firstCharIndex;
			LastCharIndex = lastCharIndex;
		}

		public ushort FirstCharIndex { get; }
		
		public ushort LastCharIndex { get; }

		public override string ToString() => $"[{FirstCharIndex}, {LastCharIndex}]";
	}
}