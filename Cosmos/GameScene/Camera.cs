using Cosmos.Core;
using SFML.Graphics;
using SFML.System;

namespace Cosmos.GameScene
{
	internal class Camera
	{
		#region Properties
		public Vector2f Position { get; set; }
		public float Rotation { get; set; }
		public float Scale { get; set; }

		public View View => new View(Position, new Vector2f(Renderer.DEFAULT_GAME_VIEW_WIDTH * Scale, -Renderer.DEFAULT_GAME_VIEW_HEIGHT * Scale));
		public FloatRect Viewport => new FloatRect(View.Center - (View.Size / 2), View.Size);
		#endregion

		#region Constructors
		public Camera()
		{
			Position = new Vector2f(0, 0);
			Rotation = 0;
			Scale = 1;
		}
		#endregion
	}
}
