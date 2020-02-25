using System;
using System.Globalization;
using System.Linq;
using System.Reactive.Linq;
using Bioinformatics.Task1;

namespace Bioinformatics.Task2
{
	internal static class Program
	{
		private static void Main()
		{
			SetCulture();

			Enumerable
				.Range(20, 61)
				.Select(gcPercent => GetGcPercentProbability((byte) gcPercent))
				.Subscribe(new ProbabilityObserver());

			Console.ReadKey();
		}
		
		private static void SetCulture()
		{
			var culture = new CultureInfo("ru-RU")
			{
				NumberFormat = { NumberDecimalSeparator = "," },
			};

			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		}

		private static GcPercentProbability GetGcPercentProbability(byte gcPercent)
		{
			var iterationsCount = 10000;
			var minRnaSequenceLength = 30;
			
			var result = Enumerable
				.Range(0, iterationsCount)
				.Select(_ => DnaStringGenerator
					.GetRandomDnaString(1000, gcPercent)
					.GetMaxRnaSequence())
				.Count(rnaSequence => rnaSequence.Values.Length >= minRnaSequenceLength);

			var probability = (double) result / iterationsCount;
			return new GcPercentProbability(gcPercent, probability);
		}
	}
}