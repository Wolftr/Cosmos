using Cosmos.Core;
using SFML.Graphics;
using SFML.System;
using Time = Cosmos.Core.Time;

namespace Cosmos.Rendering
{
	internal class Renderer
	{
		public RenderWindow Window { get; private set; }
		public RenderTexture RenderTexture { get; private set; }
		
		public Renderer(RenderWindow window)
		{
			// Set the reference to the window
			Window = window;

			// Create the render texture
			RenderTexture = new RenderTexture(256, 192);
			// RenderTexture.SetView(new View(new Vector2f(0, 0), new Vector2f(256 * 1000, 192 * 1000)));
		}

		public void Render()
		{
			// Clear the window and render texture
			RenderTexture.Clear();
			Window.Clear();

			// First pass - Tilemap layer
			DrawTilemap();

			// Display the render texture
			RenderTexture.Display();

			// Draw game scene render texture to the window
			IntRect textureSpriteRect = new IntRect(0, 0, 256, 192);
			Sprite textureSprite = new Sprite(RenderTexture.Texture, textureSpriteRect);
			textureSprite.Scale = new Vector2f(Window.Size.X / 128, Window.Size.Y / 96);
			Window.Draw(textureSprite);

			// Debug information pass
			DrawDebugInfo();

			// Display the window
			Window.Display();
		}

		public void DrawTilemap()
		{
			// TODO: Tiles do not move smoothly with the view. They snap to the nearest 8 pixel position in screenspace
			RenderTexture.GetView().Move(new Vector2f(0, -1 * Time.DeltaTime));

			// Get the render texture's viewport
			View view = RenderTexture.GetView();
			FloatRect viewport = new FloatRect(view.Center - (view.Size / 2), view.Size);
			Logger.LogInfo(viewport);

			// Create the tile sprite
			Sprite tile = new Sprite();
			tile.Origin = new Vector2f(4, 4);

			// Draw each tile
			for (int y = 0; y < 32; y++)
			{
				for (int x = 0; x < 16; x++)
				{
					// Set the tile's position
					tile.Position = new Vector2f((x * 8) + Random.Range(-2f, 2f), (y * 8) + 4);

					// Check if the tile is outside of the bounds of the camera
					FloatRect tileBounds = new FloatRect(tile.Position.X - 4, tile.Position.Y - 4, 8, 8);
					if (!viewport.Intersects(tileBounds))
						continue;

					// Set the tile's texture and draw the sprite
					tile.Texture = ResourceManager.GetTexture("Tilemaps/tile");
					RenderTexture.Draw(tile);
				}
			}
		}

		public void DrawDebugInfo()
		{
			// Draw FPS display
			Font font = ResourceManager.GetFont("CascadiaCode");
			Text text = new Text($"FPS: {(int)Time.FPS}", font);
			text.Scale = new Vector2f(0.5f, 0.5f);
			text.OutlineColor = Color.Black;
			text.OutlineThickness = 2;
			text.FillColor = Color.Green;
			Window.Draw(text);
		}
	}
}
