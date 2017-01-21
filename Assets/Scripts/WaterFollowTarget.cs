using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollowTarget : MonoBehaviour {
  public GameObject m_Target;
  public float m_XOffset;
	
	// Update is called once per frame
	void Update () {
    Vector3 target_pos = m_Target.transform.position; 
    Vector3 pos = transform.position;

    transform.position = new Vector3 (target_pos.x + m_XOffset, pos.y, pos.z);
	}
}
