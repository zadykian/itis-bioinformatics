using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bioinformatics.Task2
{
	internal class ProbabilityObserver : IObserver<GcPercentProbability>
	{
		private readonly IList<GcPercentProbability> probabilities = new List<GcPercentProbability>();
		
		public void OnCompleted()
		{
			var directory = Directory.GetCurrentDirectory();
			var filePath = Path.Combine(directory, "probabilities.txt");
			File.WriteAllLines(filePath, probabilities.Select(probability => probability.ToString()));
		}

		public void OnError(Exception error)
		{
			throw error;
		}

		public void OnNext(GcPercentProbability value)
		{
			Console.WriteLine(value);
			probabilities.Add(value);
		}
	}
}