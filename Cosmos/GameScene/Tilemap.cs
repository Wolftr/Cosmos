namespace Cosmos.GameScene
{
    internal class Tilemap : GameObject
	{
		public int[,] Tiles { get; private set; } 

		public Tilemap(int width, int height) : base("Tilemap", new Vector2f(0, 0))
		{
			// Create the tile array
			Tiles = new int[width, height];
		}

		#region Methods
		public override void Draw(RenderTarget renderTarget)
		{
			// Create the tile sprite
			Sprite tile = new Sprite();
			tile.Origin = new Vector2f(4, 4);

			// Draw tilemap
			for (int y = 0; y < Tiles.GetLength(1); y++)
			{
				for (int x = 0; x < Tiles.GetLength(0); x++)
				{
					// Set the tile position
					tile.Position = Transform.Position + new Vector2f((x * 8) + 4, (y * 8) + 4);

					// Set the tile texture
					tile.Texture = ResourceManager.GetTexture("Tilemaps/tile");

					// Draw the tile
					if (Tiles[x, y] == 1)
						renderTarget.Draw(tile);
				}
			}
		}
		#endregion
	}
}
