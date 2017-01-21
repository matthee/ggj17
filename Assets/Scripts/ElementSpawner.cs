using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {
  public GameObject m_Origin;
  public bool m_ApplyForce;
  public Vector3 m_Force;

  public bool m_ApplyRotation = true;
  public float m_SpawnCount;

  public GameObject m_Prefab;

  private List<GameObject> elements = new List<GameObject>();
  	// Use this for initialization
	void Start () {
    for (int i = 0; i < m_SpawnCount; i++) {
      GameObject element = Instantiate (m_Prefab);
      element.transform.position = new Vector3(m_Origin.transform.position.x, m_Origin.transform.position.y + 100*i, m_Origin.transform.position.z);

      if (m_ApplyRotation) {
        element.transform.rotation = m_Origin.transform.rotation;
      }

      element.transform.parent = transform;
      element.SetActive (false);

      elements.Add (element);
    }
  }

  public void Release () {
    Debug.Log ("Releasing Barrels");
    foreach (GameObject element in elements) {
      element.SetActive (true);

      if (m_ApplyForce) {
        element.GetComponent<Rigidbody> ().AddForce (m_Force, ForceMode.Impulse);
      }
    }
  }
}
