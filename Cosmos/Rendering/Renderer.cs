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
			RenderTexture = new RenderTexture(256, 256);
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
			IntRect textureSpriteRect = new IntRect(0, 0, 256, 256);
			Sprite textureSprite = new Sprite(RenderTexture.Texture, textureSpriteRect);
			textureSprite.Scale = new Vector2f(Window.Size.X / 128, Window.Size.Y / 128);
			Window.Draw(textureSprite);

			// Debug information pass
			DrawDebugInfo();

			// Display the window
			Window.Display();
		}

		public void DrawTilemap()
		{
			Sprite tile = new Sprite();
			tile.Origin = new Vector2f(4, 4);
			
			// Draw each tile
			for (int x = 0; x < 16; x++)
			{
				for (int y = 0; y < 16; y++)
				{
					tile.Texture = ResourceManager.GetTexture("Tilemaps/tile");
					tile.Position = new Vector2f((x * 8) + 4, (y * 8) + 4);
					tile.Rotation = 90 * x;
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
