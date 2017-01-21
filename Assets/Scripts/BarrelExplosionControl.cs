using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosionControl : MonoBehaviour {
	public GameObject m_Explosion;

	private WaitForSeconds wait;

	private Rigidbody rigid_body;

	// Use this for initialization
	void Awake () {
		rigid_body = GetComponent<Rigidbody> ();
		wait = new WaitForSeconds (1f);
	}
	


	void OnCollisionEnter(Collision collision) {
		if (collision.rigidbody == null) {
			return;
		}

		Vector3 diff = collision.rigidbody.velocity - rigid_body.velocity;
		Debug.Log (diff.sqrMagnitude);
		if (collision.transform.tag == "Player" || diff.sqrMagnitude > 2f) {
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
			gameObject.GetComponent<MeshCollider> ().enabled = false;
			m_Explosion.SetActive (true);
			StartCoroutine (waitAndDestroy());
		}
	}

	IEnumerator waitAndDestroy() {
		yield return wait;
		gameObject.SetActive (false);
	}
}
