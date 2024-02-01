using Cosmos.GameScene;
using Cosmos.InputManagement;
using Cosmos.Rendering;
using SFML.Graphics;
using SFML.Window;
using System;

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

        public bool IsRunning { get; private set; }

        public RenderWindow Window { get; private set; }
        public Renderer Renderer { get; private set; }

        public Scene ActiveScene { get; private set; }
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

            Logger.LogInfo("Initializing the application...");

            // Create the game window
            Logger.LogInfo("Creating window...");
            try
            {
                Window = new RenderWindow(new VideoMode(1280, 720), "Cosmos", Styles.Close);
            }
            catch (Exception ex)
            {
                Logger.LogFatal(ex);
            }
            Window.SetVerticalSyncEnabled(true);
            Window.SetKeyRepeatEnabled(false);

            // Create the renderer
            Logger.LogInfo("Creating the renderer...");
            Renderer = new Renderer(Window);

            // Subscribe to window events
            Window.Closed += OnWindowClosed;
            Window.KeyPressed += Input.OnKeyPressed;
            Window.KeyReleased += Input.OnKeyReleased;
        }
        #endregion

        #region Methods
        public void Start()
        {
            // Set the game to run
            Logger.LogInfo("Starting the application...");
            IsRunning = true;

            ActiveScene = new Scene();
            ActiveScene.AddSceneObject(new Tilemap(16, 16));
        }

        public void PollInput()
        {
            // Dispatch window events
            Window.DispatchEvents();
        }

        public void Update()
        {
            // Update time
            Time.Update();

            ActiveScene.Update();

            // Reset button states at the end of the frame
            Input.ResetButtonStates();
        }

        public void Render()
        {
            // Render
            Renderer.Render();
        }

        public void Exit()
        {
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
            Exit();
        }
        #endregion
    }
}
