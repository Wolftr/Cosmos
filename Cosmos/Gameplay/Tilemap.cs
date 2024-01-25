using Cosmos.Core;

namespace Cosmos.Gameplay
{
	internal class Tilemap
	{
		public int[,] Tiles { get; private set; } 

		public Tilemap(int width, int height)
		{
			Tiles = new int[width, height];

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Tiles[x, y] = Random.Range(0, 2);
				}
			}
		}
	}
}
