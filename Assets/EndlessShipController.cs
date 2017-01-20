using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessShipController : MonoBehaviour {

  public GameObject sectionPrefab;
  public float sectionLength;

  public GameObject player;
  public float generateAhead;

  private float generatedLength;


	// Use this for initialization
	void Start () {
    generatedLength = 0;	
	}
	
	// Update is called once per frame
	void Update () {
    float offx = player.transform.position.x;
    Debug.Log("Player offset: "+offx);


    int itemcount = 0;
    while (offx + generateAhead > generatedLength ) {
      GameObject section = Instantiate (sectionPrefab);
      
      section.transform.position = new Vector3 (generatedLength, 0, 0);
      generatedLength += sectionLength; 

      itemcount++;

      if (itemcount > 10) {

        Debug.Log ("error");
        break;
      }
    }
	}
}
