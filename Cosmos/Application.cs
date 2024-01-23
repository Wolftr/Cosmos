using Cosmos.Core;
using Cosmos.Rendering;
using Platformer.Core;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Cosmos
{
    internal class Application
	{
		#region Properties
		public static Application Instance 
		{
			get => _instance;
			private set
			{
				if (Instance != null)
					Logger.LogWarning($"Singleton of type {nameof(Application)} was attempted to be set but the singleton was not null!");
				else
					_instance = value;
			}
		}

		public RenderWindow Window { get; private set; }
		public Renderer Renderer { get; private set; }

		public bool IsRunning { get; private set; }
		public int ExitCode { get; private set; }
		#endregion

		#region Fields
		private static Application _instance;
		#endregion

		#region Constructors
		public Application()
        {
			// Initialize singleton
			Instance = this;
			if (Instance != this)
				return;

			Logger.LogInfo("Starting the game...");

			// Create the game window
			Logger.LogInfo("Creating window...");
			try 
			{ 
				Window = new RenderWindow(new VideoMode(256 * 2, 256 * 2), "Cosmos", Styles.Titlebar | Styles.Close); 
			}
			catch (Exception ex) 
			{ 
				Logger.LogFatal(ex);
			}
			Window.SetTitle("Cosmos");
			Window.SetVerticalSyncEnabled(true);

			// Create the renderer
			Logger.LogInfo("Creating the renderer...");
			Renderer = new Renderer(Window);

			// Subscribe to window events
			Window.Closed += OnWindowClosed;
        }
		#endregion

		#region Methods
		public void Start()
		{
			// Set the game to run
			IsRunning = true;

		}

		public void PollInput()
		{
			// Dispatch window events
			Window.DispatchEvents();
		}

		public void Update()
		{

		}

		public void Render()
		{
			// Render
			Renderer.Render();
		}

		public void Exit(int code = 0)
		{
			// Set the exit code
			if (IsRunning)
				ExitCode = code;

			// Set the game to exit at the end of the frame
			IsRunning = false;
		}

		public void CleanUp()
		{

		}
		#endregion

		#region Event Handlers
		private void OnWindowClosed(object sender, EventArgs e)
		{
			Exit(0);
		}
		#endregion
	}
}
