using Cosmos.Core;
using SFML.System;

namespace Cosmos.Gameplay
{
    internal class GameScene
    {
		public Vector2f CameraFollowPoint { get; set; }

		public Player Player { get; private set; }

        public Tilemap Tilemap { get; private set; }

        public GameScene()
        {
			Player = new Player();
			Tilemap = new Tilemap(16, 16);
        }

		public void Update()
		{
			Player.Update();
			CameraFollowPoint = Player.Transform.Position;
		}
    }
}
