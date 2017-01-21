using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Utility;

public class Player : MonoBehaviour {
  private CollisionManager m_CollisionManager;
  public GameController m_GameController;
   
  private bool m_Alive;

  public bool alive {
    get { return m_Alive; }
  }

	// Use this for initialization
	void Start () {
    m_CollisionManager = GetComponent<CollisionManager> ();
    Reset ();
	}

  public void Reset () {
    m_Alive = true;
    GetComponent<Rigidbody> ().velocity = Vector3.zero;
	GetComponent<PlayerControl> ().enabled = true;
	GetComponent<Animator> ().enabled = true;
	GetComponent<ThirdPersonCharacter> ().enabled = true;
	GetComponent<Rigidbody> ().freezeRotation = true;
	Camera.main.GetComponent<FollowTarget> ().enabled = true;
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

	void OnCollisionEnter(Collision collision) {
		
		if (collision.transform.tag == "CanDestroy") {
			Die ();
		}
	}

  public void Die () {
    if (m_Alive) {
	  GetComponent<PlayerControl> ().enabled = false;
	  GetComponent<Animator> ().enabled = false;
	  GetComponent<ThirdPersonCharacter> ().enabled = false;
	  GetComponent<Rigidbody> ().freezeRotation = false;
	  Camera.main.GetComponent<FollowTarget> ().enabled = false;
	  
      Debug.Log ("Player dies!");
     
      // TODO: Show Game Over Scene
      // TODO: Reset The game Status

      m_Alive = false;
	  m_GameController.Reset ();
    }
  }
}
