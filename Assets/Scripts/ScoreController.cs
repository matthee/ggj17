using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
  public GameObject player;
  public GameObject scoreTextField;

  private Text scoreTextFieldText;

  private int m_CollectableScore;

  [HideInInspector]
  public int score {
    get {
      return (int) player.transform.position.x + m_CollectableScore;
    }
  }


	// Use this for initialization
	void Start () {
    scoreTextFieldText = scoreTextField.GetComponent<Text> ();
    m_CollectableScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
    scoreTextFieldText.text = "Score: " + score;
	}

  public void AddScore(int score) {
    m_CollectableScore += score;
  }
}
