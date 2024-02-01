using SFML.System;

namespace Cosmos
{
    internal static class Time
    {
        #region Properties
        public static float DeltaTime { get; private set; }

        public static float FPS => 1 / DeltaTime;
        #endregion

        #region Fields
        private static readonly Clock _frameTimer;
        #endregion

        #region Constructors
        static Time()
        {
            _frameTimer = new Clock();
        }
        #endregion

        #region Methods
        public static void Update()
        {
            // Calculate DeltaTime
            DeltaTime = _frameTimer.ElapsedTime.AsSeconds();
            _frameTimer.Restart();
        }
        #endregion
    }
}
