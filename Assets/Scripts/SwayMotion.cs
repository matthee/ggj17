using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayMotion : MonoBehaviour {
	public float m_waveMagnitude = .90f;
	public float m_offset = 100f;
	public float m_frequency = 1.98f;
	public float m_HeightOffset = 0.8f;

	private float startTime;

	void Start () {
		startTime = Time.time;
	}
	
	void FixedUpdate () {
		float t = Time.timeSinceLevelLoad;

		transform.position = Vector3.Lerp(transform.position, new Vector3 (0, m_waveMagnitude * Mathf.Sin (m_frequency*(t)) + m_HeightOffset, 0), 0.5f);
		transform.rotation = Quaternion.Euler (Mathf.Rad2Deg * Mathf.Atan(-Mathf.Cos (m_frequency*(t)) / 5f), 0,0);

//		Ray ray = new Ray (transform.position + Vector3.up, Vector3.down);
//		RaycastHit[] hits = Physics.RaycastAll (ray, 1000f);
//		Debug.Log (hits.Length);
//		foreach (RaycastHit hit in hits) {
//			Debug.Log (hit.transform.tag);
//			if (hit.transform.tag == "Water") {
//				transform.position = hit.point;
//				break;
//			}
//		}
//
//
//		Debug.DrawRay (transform.position + Vector3.up, Vector3.down, Color.cyan);
	}
}
