using Cosmos.Extensions;

namespace Cosmos.GameScene.Collision
{
	internal static class CollisionManager
	{
		#region Properties
		public static List<Collider> Colliders = new List<Collider>();
		#endregion

		#region Methods
		public static void SolveCollisions()
		{
			// Loop through each collider
			foreach (Collider colliderA in Colliders)
			{
				foreach (Collider colliderB in Colliders)
				{
					// Continue if the colliders being compared are the same
					if (colliderA == colliderB)
						continue;

					// Continue if the colliders are not overlapping
					if (!EvaluateCollision(colliderA, colliderB))
						continue;

					// Solve the collision

				}
			}
		}

		public static bool EvaluateCollision(Collider colliderA, Collider colliderB) 
		{
			// This method should be updated to handle any type of collider against any other type
			return EvaluateBoxBoxCollision(colliderA as BoxCollider, colliderB as BoxCollider);
		}

		public static bool EvaluateBoxBoxCollision(BoxCollider colliderA, BoxCollider colliderB)
		{
			return colliderA.Bounds.Intersects(colliderB.Bounds);
		}

		public static void SolveCollision(Collider colliderA, Collider colliderB)
		{
			// This method should be updated to handle any type of collider against each other
			SolveBoxBoxCollision(colliderA as BoxCollider, colliderB as BoxCollider);
		}

		public static void SolveBoxBoxCollision(BoxCollider colliderA, BoxCollider colliderB)
		{
			// TODO: Factor in game object position instead of just the rect position
			FloatRect intersectionRect = colliderA.Bounds.GetIntersection(colliderB.Bounds);
		}
		#endregion
	}
}
