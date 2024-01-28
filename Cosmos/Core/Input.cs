using SFML.System;
using SFML.Window;

namespace Cosmos.Core
{
	internal static class Input
	{
		#region Properties
		private static Button[] Buttons { get; set; }
		#endregion

		#region Constructors
		static Input()
		{
			// Create the button array
			Buttons = new Button[(int)Keyboard.Key.KeyCount];

			// Initialize the buttons
			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i] = new Button((Keyboard.Key)i);
			}
		}
		#endregion

		#region Methods
		public static bool GetKeyPressed(Keyboard.Key keyCode)
		{
			return GetKeyPressed((int)keyCode);
		}

		public static bool GetKeyPressed(int keyCode)
		{
			// Return false if the button is invalid
			if (keyCode < 0 || keyCode >= Buttons.Length)
				return false;

			return Buttons[keyCode].Pressed;
		}

		public static bool GetKeyHeld(Keyboard.Key keyCode)
		{
			return GetKeyHeld((int)keyCode);
		}

		public static bool GetKeyHeld(int keyCode)
		{
			// Return false if the button is invalid
			if (keyCode < 0 || keyCode >= Buttons.Length)
				return false;

			return Buttons[keyCode].Held;
		}

		public static bool GetKeyReleased(Keyboard.Key keyCode)
		{
			return GetKeyReleased((int)keyCode);
		}

		public static bool GetKeyReleased(int keyCode)
		{
			// Return false if the button is invalid
			if (keyCode < 0 || keyCode >= Buttons.Length)
				return false;

			return Buttons[keyCode].Released;
		}

		public static void ResetButtonStates()
		{
			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i].Reset();
			}
		}

		public static int GetAxis(Keyboard.Key positiveKey, Keyboard.Key negativeKey)
		{
			if (GetKeyHeld(positiveKey) && !GetKeyHeld(negativeKey))
				return 1;
			else if (GetKeyHeld(negativeKey) && !GetKeyHeld(positiveKey))
				return -1;
			else
				return 0;
		}
		#endregion

		#region Event Handlers
		internal static void OnKeyPressed(object sender, KeyEventArgs e)
		{
			// Return if unhandled key
			if ((int)e.Code == -1)
				return;

			// Press the specified button
			Buttons[(int)e.Code].Press();
		}

		internal static void OnKeyReleased(object sender, KeyEventArgs e)
		{
			// Return if unhandled key
			if ((int)e.Code == -1)
				return;

			// Release the specified button
			Buttons[(int)e.Code].Release();
		}
		#endregion
	}
}
