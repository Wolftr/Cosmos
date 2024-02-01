namespace Cosmos
{
    internal class Program
	{
		static int Main()
		{
			try
			{
				// Initialize the logger
				Logger.InitializeLogStream();
				Logger.LogInfo("Logger initialized!");

				// Create the game
				Application game = new Application();

				// Start the game
				game.Start();

				// Game loop
				while (game.IsRunning)
				{
					// Input
					game.PollInput();

					// Update
					game.Update();

					// Render
					game.Render();
				}

				// Clean up on exit
				game.CleanUp();
			}
			catch (Exception e)
			{
				// Log the exception as a fatal error and close the log stream
				Logger.LogFatal(e);
				Logger.CloseLogStream();
				throw;
			}

			// Close the log stream
			Logger.CloseLogStream();

			return 0;
		}
	}
}