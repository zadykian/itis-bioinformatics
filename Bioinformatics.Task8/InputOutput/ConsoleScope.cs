using System;

namespace Bioinformatics.Task8
{
	/// <summary>
	/// Контекст отображения текста в терминале.
	/// </summary>
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

		/// <summary>
		/// Создать контекст вывода информационного сообщения.
		/// </summary>
		public static ConsoleScope Info => new ConsoleScope(ConsoleColor.DarkGreen, ConsoleColor.Gray);

		/// <summary>
		/// Создать контекст вывода сообщения об ошибке.
		/// </summary>
		public static ConsoleScope Error => new ConsoleScope(ConsoleColor.DarkRed, ConsoleColor.Gray);

		/// <summary>
		/// Создать контекст ввода данных пользователем.
		/// </summary>
		public static ConsoleScope Input => new ConsoleScope(ConsoleColor.DarkCyan, ConsoleColor.Black);

		/// <summary>
		/// Создать контекст вывода заголовка результата.
		/// </summary>
		public static ConsoleScope ResultHeader => new ConsoleScope(ConsoleColor.DarkGray, ConsoleColor.Gray);

		/// <summary>
		/// Создать контекст вывода по умолчанию.
		/// </summary>
		public static ConsoleScope Default => new ConsoleScope(Console.BackgroundColor, Console.ForegroundColor);
	}
}