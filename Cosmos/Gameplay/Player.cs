using Cosmos.Core;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Cosmos.Gameplay
{
	internal class Player
	{
		#region Constants
		const float MOVEMENT_SPEED = 30f;
		#endregion

		#region Properties
		public Transform Transform { get; private set; }
		#endregion

		#region Constructors
		public Player()
		{
			Transform = new Transform(new Vector2f(0, 0));
		}
		#endregion

		#region Methods
		public void Update()
		{
			// Get the movement direction
			Vector2f movementInputDirection = new Vector2f();
			movementInputDirection.X = Input.GetAxis(Keyboard.Key.Right, Keyboard.Key.Left);
			movementInputDirection.Y = Input.GetAxis(Keyboard.Key.Up, Keyboard.Key.Down);

			// Apply movement
			Transform.Position += movementInputDirection * Core.Time.DeltaTime * MOVEMENT_SPEED;
		}

		public Sprite GetSprite()
		{
			Sprite sprite = new Sprite(ResourceManager.GetTexture("Tilemaps/tile"));
			sprite.Position = Transform.Position;
			sprite.Rotation = Transform.Rotation;
			sprite.Scale = Transform.Scale;
			return sprite;
		}
		#endregion
	}
}
