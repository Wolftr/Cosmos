using SFML.System;

namespace Cosmos.Gameplay
{
	internal class Transform
	{
		#region Properties
		public Vector2f Position { get; set; }
		public float Rotation { get; set; }
		public Vector2f Scale { get; set; }
		#endregion

		#region Constructors
		public Transform() 
		{
			Position = new Vector2f(0, 0);
			Rotation = 0;
			Scale = new Vector2f(1, 1);
		}

		public Transform(Vector2f position)
		{
			Position = position;
			Rotation = 0;
			Scale = new Vector2f(1, 1);
		}
		#endregion
	}
}
