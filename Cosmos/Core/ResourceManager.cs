﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Cosmos.Core
{
    internal static class ResourceManager
	{
		#region Properties
		private static Dictionary<string, Texture> TextureCache { get; set; }
		private static Dictionary<string, Font> FontCache { get; set; }

		static string ResourcesPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Resources";
		static string TexturesPath => ResourcesPath + "\\Textures\\";
		static string FontsPath => ResourcesPath + "\\Fonts\\";
		#endregion

		#region Constructor
		static ResourceManager()
		{
			// Initialize all caches
			TextureCache = new Dictionary<string, Texture>();
			FontCache = new Dictionary<string, Font>();
		}
		#endregion

		#region Methods
		public static Texture GetTexture(string name)
		{
			// Check if the font is already loaded
			if (!TextureCache.ContainsKey(name))
			{
				// Load the font if it has not been loaded
				Texture texture;
				try
				{
					// Try to load the font from file
					texture = new Texture(TexturesPath + name + ".png");
					TextureCache.Add(name, texture);
				}
				catch (Exception ex)
				{
					Logger.LogFatal(ex);
					Application.Instance.Exit(1);
				}
			}

			// Return the font
			return TextureCache.GetValueOrDefault(name);
		}

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
