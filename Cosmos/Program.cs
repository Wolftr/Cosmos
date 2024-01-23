namespace Cosmos
{
    internal class Program
	{
		static int Main()
		{
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

			return game.ExitCode;
		}
	}
}