using UnityEngine;
using System.Collections.Generic;

public class CollisionManager : MonoBehaviour {

	private List<Collision> collisions;

	void Start() {
		collisions = new List<Collision>();
	}

	void FixedUpdate() {
		collisions.Clear ();
	}

	void OnCollisionStay(Collision coll) {
		collisions.Add (coll);
	}

	void OnDrawGizmos() {
		if (collisions == null) return;

		foreach (Collision coll in collisions) {
			Gizmos.color = Color.white;
			Collider collider = coll.collider;
			Gizmos.DrawCube (collider.bounds.center, collider.bounds.size);

			Gizmos.color = Color.red;
			ContactPoint[] points = coll.contacts;
			foreach (ContactPoint point in points) {
				Gizmos.DrawCube (point.point, Vector3.one * 10);
				Gizmos.DrawRay (point.point, point.normal * 25);
			}
		}
	}

	public Collision[] Collisions {
		get {
			Collision[] collision_array = new Collision[collisions.Count];
			collisions.CopyTo(collision_array);
			return collision_array;
		}
	}
}