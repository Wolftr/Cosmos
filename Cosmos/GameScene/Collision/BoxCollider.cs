using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.GameScene.Collision
{
	internal class BoxCollider : Collider
	{
		public GameObject GameObject { get; private set; }
		public FloatRect Bounds { get; set; }

		public BoxCollider() 
		{
			Bounds = new FloatRect(GameObject.Transform.Position, new Vector2f(1, 1));
		}
	}
}
