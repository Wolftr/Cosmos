using Cosmos.GameScene;
using SFML.Graphics;
using SFML.System;

namespace Cosmos.Rendering
{
    internal class Renderer
    {
        #region Constants
        public const uint DEFAULT_GAME_VIEW_WIDTH = 256;
        public const uint DEFAULT_GAME_VIEW_HEIGHT = 144;
        #endregion

        #region Properties
        public RenderWindow Window { get; private set; }

        private static View UIView => new View(new FloatRect(0, 0, 1920, 1080));
        #endregion

        #region Constructors
        public Renderer(RenderWindow window)
        {
            // Set the reference to the window
            Window = window;
        }
        #endregion

        #region Methods
        public void Render()
        {
            // Clear the window
            Window.Clear();

            // Draw the game scene
            DrawGameScene();

            // Draw the UI
            DrawUI();

            // Display the window
            Window.Display();
        }

        public void DrawGameScene()
        {
            // Set the window view for game rendering
            Window.SetView(Scene.ActiveScene.Camera.View);

            // Draw each game object to the window
            foreach (GameObject obj in Scene.ActiveScene.GameObjects)
            {
                obj.Draw(Window);
            }
        }

        public void DrawUI()
        {
            // Set the window view for UI rendering
            Window.SetView(UIView);

            // Draw info for debugging
            DrawDebugInfo();
        }

        public void DrawDebugInfo()
        {
            // Draw FPS display
            Font font = ResourceManager.GetFont("CascadiaCode");
            Text text = new Text($"FPS: {(int)Time.FPS}", font);
            text.Scale = new Vector2f(0.75f, 0.75f);
            text.OutlineColor = Color.Black;
            text.OutlineThickness = 2;
            text.FillColor = Color.Green;
            Window.Draw(text);
        }
        #endregion
    }
}
