using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private CollisionManager m_CollisionManager;
   
  private bool alive = true;

	// Use this for initialization
	void Start () {
    m_CollisionManager = GetComponent<CollisionManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnCollisionStay(Collision coll) {
    // first, see if the player is touching anything else.
    Collision[] collisions = m_CollisionManager.Collisions;

    if (collisions.GetLength (0) == 0) return;

    // cycle through the other collisions and detect what the normal is.
    // if the difference between the normals is more than 90 degrees, the player has been crushed.
    Vector3 new_normal = coll.contacts[0].normal;

    foreach (Collision existing_coll in collisions) {
      Vector3 existing_normal = existing_coll.contacts[0].normal;

      float normal_angle = Vector3.Angle (new_normal, existing_normal);
      if (normal_angle > 135) {
        Die ();
      }
    }
  }

  private void Die () {
    alive = false;

    if (alive) {
      Debug.Log ("Player dies!");

      // TODO: Show Game Over Scene
      // TODO: Reset The game Status
    }

  }
}
