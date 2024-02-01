namespace Cosmos.GameScene
{
    internal class Scene
    {
		#region Properties
		/// <summary>
		/// The current active scene
		/// </summary>
		public static Scene ActiveScene => Application.Instance.ActiveScene;

		/// <summary>
		/// Describes scene's current view
		/// </summary>
		public Camera Camera { get; private set; }

		/// <summary>
		/// A list of every GameObject in the scene
		/// </summary>
		public List<GameObject> GameObjects { get; private set; }
		#endregion

		#region Constructor
		public Scene()
        {
			// Initialize the camera
			Camera = new Camera();

			// Initialize the GameObject list
			GameObjects = new List<GameObject>();
        }
		#endregion

		#region Methods
		public void AddSceneObject(GameObject gameObject)
		{
			gameObject.Scene = this;
			GameObjects.Add(gameObject);
		}

		public void Update()
		{
			// Update each game object
			foreach (GameObject obj in GameObjects)
			{
				obj.Update();
			}
		}
		#endregion
	}
}
