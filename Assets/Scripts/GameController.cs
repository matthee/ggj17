﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  public GameObject m_EndlessShipController;
  public GameObject m_Player;
  public List<GameObject> m_SpawnPoints;

	// Use this for initialization
	void Start () {
    Reset ();
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown ("r")) {
      Reset ();
    }
	}

  public void Reset () {
    Debug.Log ("Resetting Game");
    MovePlayerToSpawnPoint ();
    ResetPlayer ();
    ResetEndlessShipGenerator ();
  }

  private void MovePlayerToSpawnPoint() {
    GameObject spawn = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)];
    
    m_Player.transform.position = spawn.transform.position;
    m_Player.transform.rotation = spawn.transform.rotation;
  }

  private void ResetPlayer () {
    m_Player.GetComponent<Player> ().Reset(); 
  }

  private void ResetEndlessShipGenerator () {
    m_EndlessShipController.GetComponent<EndlessShipController> ().Reset ();
  }
}
