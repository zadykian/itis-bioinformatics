using System;
using System.Linq;

namespace Bioinformatics.Task3
{
	internal readonly struct AlignedStrings : IEquatable<AlignedStrings>
	{
		public AlignedStrings(string firstString, 
			string secondString, 
			uint[] diffIndices)
		{
			FirstString = firstString;
			SecondString = secondString;
			DiffIndices = diffIndices;
		}

		public string FirstString { get; }

		public string SecondString { get; }

		public uint[] DiffIndices { get; }

		public bool Equals(AlignedStrings other)
		{
			return 
				string.Equals(FirstString, other.FirstString, StringComparison.OrdinalIgnoreCase) 
				&& string.Equals(SecondString, other.SecondString, StringComparison.OrdinalIgnoreCase) 
				&& DiffIndices.SequenceEqual(other.DiffIndices);
		}

		public override bool Equals(object obj)
		{
			return obj is AlignedStrings other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(FirstString, StringComparer.OrdinalIgnoreCase);
			hashCode.Add(SecondString, StringComparer.OrdinalIgnoreCase);
			hashCode.Add(DiffIndices);
			return hashCode.ToHashCode();
		}
	}
}