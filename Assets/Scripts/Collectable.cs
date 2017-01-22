using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    

  public void Update() {
    transform.Rotate (new Vector3 (0, Time.deltaTime, 0));
  }
  public void OnTriggerEnter(Collider coll) {
    if (coll.transform.tag == "Player") {
      ScoreController sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ScoreController> ();

      sc.AddScore(100);

      Destroy (gameObject);
    }
  }
}
