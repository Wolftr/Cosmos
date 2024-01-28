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
					if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
						Tiles[x, y] = 1;
					else
						Tiles[x, y] = 0;
				}
			}
		}
	}
}
