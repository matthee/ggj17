using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
  public GameObject player;
  public GameObject scoreTextField;

  private Text scoreTextFieldText;

  [HideInInspector]
  public int score {
    get {
      return (int) player.transform.position.x;
    }
  }
	// Use this for initialization
	void Start () {
    scoreTextFieldText = scoreTextField.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
    scoreTextFieldText.text = "Score: " + score;
	}
}
