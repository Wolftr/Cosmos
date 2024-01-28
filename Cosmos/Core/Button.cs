using SFML.System;
using SFML.Window;

namespace Cosmos.Core
{
	internal struct Button
	{
		#region 
		public Keyboard.Key KeyCode { get; set; }

		public bool Pressed { get; private set; }
		public bool Held { get; private set; }
		public bool Released { get; private set; }
		#endregion

		#region Constructors
		public Button(Keyboard.Key keyCode)
		{
			// Set the binding
			KeyCode = keyCode;

			// Initialize variables
			Pressed = false;
			Held = false;
			Released = false;
		}
		#endregion

		#region Methods
		public void Reset()
		{
			Pressed = false;
			Released = false;
		}

		public void Press()
		{
			Pressed = true;
			Held = true;
		}

		public void Release()
		{
			Held = false;
			Released = true;
		}
		#endregion
	}
}
