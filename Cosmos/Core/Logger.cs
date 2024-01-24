using System;

namespace Cosmos.Core
{
	internal static class Logger
	{
		#region Properties
		private static ConsoleColor LogInfoColor => ConsoleColor.White;
		private static ConsoleColor LogWarningColor => ConsoleColor.Yellow;
		private static ConsoleColor LogErrorColor => ConsoleColor.Red;
		private static ConsoleColor LogFatalColor => ConsoleColor.DarkRed;
		#endregion

		#region Methods
		/// <summary>
		/// Logs an info message to the console
		/// </summary>
		/// <param name="message"></param>
		public static void LogInfo(object message)
		{
			Log("Info", LogInfoColor, message);
		}

		/// <summary>
		/// Logs a warning message to the console
		/// </summary>
		/// <param name="message"></param>
		public static void LogWarning(object message)
		{
			Log("Warning", LogWarningColor, message);
		}

		/// <summary>
		/// Logs an error message to the console
		/// </summary>
		/// <param name="message"></param>
		public static void LogError(object message)
		{
			Log("Error", LogErrorColor, message);
		}

		/// <summary>
		/// Logs a fatal error message to the console
		/// </summary>
		/// <param name="message"></param>
		public static void LogFatal(object message)
		{
			Log("Fatal Error", LogFatalColor, message);
		}

		/// <summary>
		/// Logs a message with the specified name, color, and message to the console
		/// </summary>
		/// <param name="logTitle"></param>
		/// <param name="color"></param>
		/// <param name="message"></param>
		private static void Log(string logTitle, ConsoleColor color, object message)
		{
			Console.ForegroundColor = color;
			Console.WriteLine($"[{logTitle} ({DateTime.Now:HH:mm:ss})] {message}");
		}
		#endregion
	}
}
