using Cosmos.InputManagement;

namespace Cosmos.GameScene
{
	internal class Player : GameObject
	{
		#region Constants
		const float MOVEMENT_SPEED = 30f;
		#endregion

		#region Constructors
		public Player() : base("Player")
		{
			
		}
		#endregion

		#region Methods
		public override void Update()
		{
			Scene.Camera.Position = Transform.Position;

			// Get the movement direction
			Vector2f movementInputDirection = new Vector2f();
			movementInputDirection.X = Input.GetAxis(Keyboard.Key.Right, Keyboard.Key.Left);
			movementInputDirection.Y = Input.GetAxis(Keyboard.Key.Up, Keyboard.Key.Down);

			// Apply movement
			Transform.Position += movementInputDirection * Time.DeltaTime * MOVEMENT_SPEED;
		}

		public override void Draw(RenderTarget renderTarget)
		{
			Sprite sprite = new Sprite(ResourceManager.GetTexture("Tilemaps/tile"));
			sprite.Position = Transform.Position;
			sprite.Rotation = Transform.Rotation;
			sprite.Scale = Transform.Scale;
			renderTarget.Draw(sprite);
		}
		#endregion
	}
}
