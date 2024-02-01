using System;
using System.IO;
using System.Reflection;

namespace Cosmos
{
    internal static class Logger
    {
        #region Properties
		private static string LogPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt";
		private static FileStream LogStream { get; set; }
		private static StreamWriter LogWriter { get; set; }

		private static ConsoleColor LogInfoColor => ConsoleColor.White;
        private static ConsoleColor LogWarningColor => ConsoleColor.Yellow;
        private static ConsoleColor LogErrorColor => ConsoleColor.Red;
        private static ConsoleColor LogFatalColor => ConsoleColor.DarkRed;
		#endregion

		#region Methods
		/// <summary>
		/// Opens the log stream for writing
		/// </summary>
		public static void InitializeLogStream()
		{
			LogStream = new FileStream(LogPath, FileMode.Create, FileAccess.Write);
			LogWriter = new StreamWriter(LogStream);
		}

		/// <summary>
		/// Closes the log stream and saves it to file
		/// </summary>
		public static void CloseLogStream()
		{
			LogWriter.Close();
		}

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
			string formattedMessage = $"[{logTitle} ({DateTime.Now:HH:mm:ss})] {message}";

			// Write the message to console
			Console.ForegroundColor = color;
            Console.WriteLine(formattedMessage);

			// Create the log stream if it is null
			if (LogStream == null)
				return;

			// Write the message to the log file
			LogWriter.WriteLine(formattedMessage);
        }
		#endregion
	}
}
