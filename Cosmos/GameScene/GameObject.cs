using SFML.Graphics;
using SFML.System;

namespace Cosmos.GameScene
{
	internal class GameObject
	{
		#region Properties
		/// <summary>
		/// The internal name of the GameObject
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The position, rotation, and scale of the GameObject
		/// </summary>
		public Transform Transform { get; private set; }

		/// <summary>
		/// The scene this GameObject belongs to
		/// </summary>
		public Scene Scene { get; set; }
		#endregion

		#region Constructors
		public GameObject()
		{
			Name = "Game Object";
			Transform = new Transform();
		}

		public GameObject(string name)
		{
			Name = name;
			Transform = new Transform();
		}

		public GameObject(Vector2f position)
		{
			Name = "Game Object";
			Transform = new Transform(position);
		}

		public GameObject(string name, Vector2f position)
		{
			Name = name;
			Transform = new Transform(position);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Handles updating the logic of the GameObject
		/// </summary>
		public virtual void Update() { }

		/// <summary>
		/// Handles drawing the GameObject to the screen
		/// </summary>
		public virtual void Draw(RenderTarget renderTarget) { }
		#endregion
	}
}
