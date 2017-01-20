using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayMotion : MonoBehaviour {
	public float m_waveMagnitude;

	private float startTime;

	void Start () {
		startTime = Time.time;
	}
	
	void FixedUpdate () {
		transform.position = new Vector3 (0, m_waveMagnitude * Mathf.Sin (Time.time - startTime), 0);
		transform.rotation = Quaternion.Euler (m_waveMagnitude * Mathf.Rad2Deg * Mathf.Cos (Time.time - startTime), 0, 0);
	}
}
