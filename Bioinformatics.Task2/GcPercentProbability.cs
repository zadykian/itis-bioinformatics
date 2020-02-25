namespace Bioinformatics.Task2
{
	internal readonly struct GcPercentProbability
	{
		public GcPercentProbability(byte gcPercent, double probability)
		{
			GcPercent = gcPercent;
			Probability = probability;
		}

		public byte GcPercent { get; }
		
		public double Probability { get; }

		public override string ToString() => $"{GcPercent}: {Probability}";
	}
}