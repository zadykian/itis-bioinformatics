using System;

namespace Bioinformatics.Task3
{
	internal class ConsoleScope : IDisposable
	{
		private readonly ConsoleColor actualBackgroundColor;
		private readonly ConsoleColor actualFontColor;

		public ConsoleScope(ConsoleColor scopeBackgroundColor, ConsoleColor scopeFontColor)
		{
			actualBackgroundColor = Console.BackgroundColor;
			actualFontColor = Console.ForegroundColor;
			Console.BackgroundColor = scopeBackgroundColor;
			Console.ForegroundColor = scopeFontColor;
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			Console.BackgroundColor = actualBackgroundColor;
			Console.ForegroundColor = actualFontColor;
		}

		public static ConsoleScope Error() => new ConsoleScope(ConsoleColor.DarkRed, ConsoleColor.Gray);
	}
}