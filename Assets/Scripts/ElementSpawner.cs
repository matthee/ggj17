using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {
  public GameObject m_Origin;
  public bool m_ApplyForce;
  public Vector3 m_Force;
  public bool m_RandomizeForce = true;
  public Vector3 m_RandomizationExtent;

  public bool m_ApplyRotation = true;
  public float m_SpawnCount;

  public Vector3 m_ElementOffset;
  public GameObject m_Prefab;

  private List<GameObject> elements = new List<GameObject>();
  	// Use this for initialization
	void Start () {
    for (int i = 0; i < m_SpawnCount; i++) {
      GameObject element = Instantiate (m_Prefab);



      element.transform.parent = transform;
      element.SetActive (false);

      elements.Add (element);
    }
  }

  public IEnumerator Release () {
    Debug.Log ("Releasing Barrels");

    for (int i = 0; i < m_SpawnCount; i++) {
      GameObject element = elements [i];

      Vector3 pos = m_Origin.transform.position + m_ElementOffset * i;
      element.transform.position = pos;

      if (m_ApplyRotation) {
        element.transform.rotation = m_Origin.transform.rotation * transform.rotation;
      }

      element.SetActive (true);

      if (m_ApplyForce) {
        Vector3 force = m_Force;

        if (m_RandomizeForce) {
          force = new Vector3 (
            RandomizeDimension(m_Force.x, m_RandomizationExtent.x),
            RandomizeDimension(m_Force.y, m_RandomizationExtent.y),
            RandomizeDimension(m_Force.z, m_RandomizationExtent.z)
          );
        }
          
        element.GetComponent<Rigidbody> ().AddForce (- force, ForceMode.Impulse);
      }

	  yield return new WaitForSeconds (0.3f);
    }
  }

  private float RandomizeDimension(float val, float extent) {
    float rand = Random.Range (-extent, extent);

    return val + rand;
  }
}
