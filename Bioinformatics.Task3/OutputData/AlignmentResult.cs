using System;

namespace Bioinformatics.Task3
{
	/// <summary>
	/// Результат выравнивания.
	/// </summary>
	internal readonly struct AlignmentResult : IEquatable<AlignmentResult>
	{
		public AlignmentResult(string stringRepresentation, 
			long score, 
			uint replacementCount, 
			uint indelCount)
		{
			StringRepresentation = stringRepresentation;
			Score = score;
			ReplacementCount = replacementCount;
			IndelCount = indelCount;
		}

		/// <summary>
		/// Строковое представление выравнивания в подстрочном виде.
		/// </summary>
		public string StringRepresentation { get; }

		/// <summary>
		/// Общая стоимость выравнивания (значение весовой функции).
		/// </summary>
		public long Score { get; }

		/// <summary>
		/// Количество замен.
		/// </summary>
		public uint ReplacementCount { get; }

		/// <summary>
		/// Суммарное количество вставок и делеций.
		/// </summary>
		public uint IndelCount { get; }

		public bool Equals(AlignmentResult other)
		{
			return 
				string.Equals(StringRepresentation, other.StringRepresentation, StringComparison.OrdinalIgnoreCase) 
				&& Score == other.Score 
				&& ReplacementCount == other.ReplacementCount 
				&& IndelCount == other.IndelCount;
		}

		public override bool Equals(object obj)
		{
			return obj is AlignmentResult other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(StringRepresentation, StringComparer.OrdinalIgnoreCase);
			hashCode.Add(Score);
			hashCode.Add(ReplacementCount);
			hashCode.Add(IndelCount);
			return hashCode.ToHashCode();
		}
	}
}