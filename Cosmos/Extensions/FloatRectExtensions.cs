namespace Cosmos.Extensions
{
	internal static class FloatRectExtensions
	{
		public static FloatRect GetIntersection(this FloatRect rect, FloatRect other)
		{
			// Return if there is no intersection
			if (!rect.Intersects(other))
				return new FloatRect(0, 0, 0, 0);

			// Calculate the corners of the intersection rect
			float top = Math.Max(rect.Top, other.Top);
			float bottom = Math.Min(rect.Top + rect.Height, other.Top + other.Height);
			float left = Math.Max(rect.Left, other.Left);
			float right = Math.Min(rect.Left + rect.Width, other.Left + other.Width);

			return new FloatRect(left, top, right - left, bottom - top); ;
		}
	}
}
