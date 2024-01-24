using Cosmos.Core;

namespace Cosmos.Gameplay
{
    internal class GameScene
    {
        public int[,] Tiles { get; private set; }

        public GameScene()
        {
			Tiles = new int[32, 32];
			for (int y = 0; y < 32; y++)
			{
				for (int x = 0; x < 32; x++)
				{
					Tiles[x, y] = Random.Range(0, 2);
				}
			}
			
        }
    }
}
