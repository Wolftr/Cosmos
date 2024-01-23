using Platformer.Core;
using SFML.Graphics;
using System.Reflection;

namespace Cosmos.Core
{
	internal static class ResourceManager
	{
		#region Properties
		static Dictionary<string, Font> FontCache { get; set; }

		static string ResourcesPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Resources";
		static string FontsPath => ResourcesPath + "\\Fonts\\";
		#endregion

		#region Constructor
		static ResourceManager()
		{
			// Initialize all caches
			FontCache = new Dictionary<string, Font>();
		}
		#endregion

		#region Methods
		public static Font GetFont(string name)
		{
			// Check if the font is already loaded
			if (!FontCache.ContainsKey(name))
			{
				// Load the font if it has not been loaded
				Font font;
				try
				{
					// Try to load the font from file
					font = new Font(FontsPath + name + ".ttf");
					FontCache.Add(name, font);
				}
				catch (Exception ex)
				{
					Logger.LogFatal(ex);
					Application.Instance.Exit(1);
				}
			}

			// Return the font
			return FontCache.GetValueOrDefault(name);
		}

		public static void ClearCache()
		{
			FontCache.Clear();
		}
		#endregion
	}
}
