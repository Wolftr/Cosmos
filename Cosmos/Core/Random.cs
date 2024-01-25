namespace Cosmos.Core
{
	internal static class Random
	{
		#region Fields
		private static readonly System.Random _random = new System.Random();
		#endregion

		#region Methods
		public static int Range(int minInclusive, int maxExclusive)
		{
			return _random.Next(minInclusive, maxExclusive);
		}

		public static float Range(float minInclusive, float maxInclusive) 
		{
			float r = _random.NextSingle();
			r *= r * (maxInclusive - minInclusive);
			r += minInclusive;
			return r;
		}
		#endregion
	}
}
