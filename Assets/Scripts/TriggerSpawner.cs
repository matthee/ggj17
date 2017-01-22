using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour {
  public BarrelContainerSpawner spawner;

  public void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      spawner.Release ();
    }
  }
}
