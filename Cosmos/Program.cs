namespace Cosmos
{
    internal class Program
	{
		static void Main()
		{
			// Create the game
			Application game = new Application();
			
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
		}
	}
}