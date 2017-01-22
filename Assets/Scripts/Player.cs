using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Utility;

public class Player : MonoBehaviour {
  private CollisionManager m_CollisionManager;
  public GameController m_GameController;
   
  private bool m_Alive;
  private GameObject m_SnapTo;
  public bool alive {
    get { return m_Alive; }
  }

	// Use this for initialization
	void Start () {
    m_CollisionManager = GetComponent<CollisionManager> ();
    Reset ();
	}

  void Update () {
    if (m_SnapTo != null) {
      transform.position = Vector3.Lerp(transform.position, m_SnapTo.transform.position + Vector3.up * 0.2f, 0.1f);
    }
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
      Ragdoll ();
		}
    if (collision.transform.tag == "Trap") {
      Die ();
      SnapTo (collision.gameObject);
    }
	}

  public void Die () {
    if (m_Alive) {
      GetComponent<PlayerControl> ().Stop ();
	  
      Debug.Log ("Player dies!");
     
      // TODO: Show Game Over Scene
      // TODO: Reset The game Status

      m_Alive = false;

	    m_GameController.ResetIn (5f);
    }
  }

  public void Explode() {
    Die ();
    Ragdoll ();
  }

  public void Ragdoll() {
    GetComponent<PlayerControl> ().enabled = false;
    //GetComponent<Animator> ().enabled = false;
    //GetComponent<ThirdPersonCharacter> ().enabled = false;
    GetComponent<Rigidbody> ().freezeRotation = false;
    Camera.main.GetComponent<FollowTarget> ().enabled = false;

  }

  public void SnapTo(GameObject go) {
    m_SnapTo = go;
    transform.parent = go.transform;
    GetComponent<PlayerControl> ().Stop ();
    GetComponent<Rigidbody> ().isKinematic = true;
  }
}
