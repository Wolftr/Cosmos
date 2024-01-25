using Cosmos.Core;

namespace Cosmos.Gameplay
{
    internal class GameScene
    {
        public Tilemap Tilemap { get; private set; }

        public GameScene()
        {
			Tilemap = new Tilemap(1, 1);
			
        }
    }
}
