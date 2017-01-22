using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

  private Animator anim;

  void Start() {

    anim = GetComponent<Animator> ();
  }

  public void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Player") {
      anim.SetBool ("Snap", true);
//      GetComponent<Rigidbody> ().isKinematic = true;
    } 
  }
}
