﻿using Cosmos.Core;
using SFML.Graphics;
using SFML.System;
using Time = Cosmos.Core.Time;

namespace Cosmos.Rendering
{
	internal class Renderer
	{
		public RenderWindow Window { get; private set; }

		private static View UIView => new View(new FloatRect(0, 0, 1920, 1080));
		private static View GameView { get; set; }
		private static FloatRect GameViewport => new FloatRect(GameView.Center - (GameView.Size / 2), GameView.Size);

		public Renderer(RenderWindow window)
		{
			// Set the reference to the window
			Window = window;

			// Initialize game view
			GameView = new View(new Vector2f(0, 0), new Vector2f(256, 144));
		}

		public void Render()
		{
			// Clear the window
			Window.Clear();

			// Draw the game scene
			DrawGameScene();

			// Draw the UI
			DrawUI();

			// Display the window
			Window.Display();
		}

		public void DrawGameScene()
		{ 
			// Set the window view for game rendering
			Window.SetView(GameView);

			DrawTilemap();

			
		}

		public void DrawUI()
		{
			// Set the window view for UI rendering
			Window.SetView(UIView);

			// Draw info for debugging
			DrawDebugInfo();
		}

		public void DrawTilemap()
		{
			GameView.Move(new Vector2f(0, Time.DeltaTime * 10));

			// Create the tile sprite
			Sprite tile = new Sprite();
			tile.Origin = new Vector2f(4, 4);

			// Draw each tile
			for (int y = 0; y < 400; y++)
			{
				for (int x = 0; x < 16; x++)
				{
					// Set the tile position
					tile.Position = new Vector2f(((x - 8) * 8) + 4, (y * 8) + 4);

					// Check if the tile is inside the window's view
					FloatRect tileBounds = new FloatRect(tile.Position.X - 4, tile.Position.Y - 4, 8, 8);
					if (!GameViewport.Intersects(tileBounds))
						continue;

					// Set the tile texture
					tile.Texture = ResourceManager.GetTexture("Tilemaps/tile");

					// Draw the tile
					Window.Draw(tile);
				}
			}
		}

		public void DrawDebugInfo()
		{
			// Draw FPS display
			Font font = ResourceManager.GetFont("CascadiaCode");
			Text text = new Text($"FPS: {(int)Time.FPS}", font);
			text.Scale = new Vector2f(0.75f, 0.75f);
			text.OutlineColor = Color.Black;
			text.OutlineThickness = 2;
			text.FillColor = Color.Green;
			Window.Draw(text);
		}
	}
}
