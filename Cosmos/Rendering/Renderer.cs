using Cosmos.Core;
using Platformer.Core;
using SFML.Graphics;
using SFML.System;

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
			DrawTilemapPass();

			// Display the render texture
			RenderTexture.Display();

			// Draw game scene render texture to the window
			IntRect textureSpriteRect = new IntRect(0, 0, 256, 256);
			Sprite textureSprite = new Sprite(RenderTexture.Texture, textureSpriteRect);
			textureSprite.Scale = new Vector2f(Window.Size.X / 256, Window.Size.Y / 256);
			Window.Draw(textureSprite);

			// Debug information pass
			Font font = ResourceManager.GetFont("CascadiaCode");
			Text text = new Text("FPS: ", font);
			text.OutlineColor = Color.Black;
			text.OutlineThickness = 2;
			text.FillColor = Color.Green;
			Window.Draw(text);

			// Display the window
			Window.Display();
		}

		public void DrawTilemapPass()
		{
			RectangleShape tile = new RectangleShape(new Vector2f(16, 16));

			// Draw each tile
			for (int x = 0; x < 16; x++)
			{
				for (int y = 0; y < 16; y++)
				{
					tile.FillColor = new Color(0, (byte)(x * 100), (byte)(y * 8));
					tile.Position = new Vector2f(x * 16, y * 16);
					RenderTexture.Draw(tile);
				}
			}
		}
	}
}
