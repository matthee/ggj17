using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessShipController : MonoBehaviour {

  public GameObject sectionPrefab;
  public float sectionLength;

  public GameObject player;
  public float generateAhead;
  public float generateBack;

  private float generatedLength;
  private LinkedList<GameObject> sections;

	// Use this for initialization
	void Start () {
    generatedLength = 0f;	
    sections = new LinkedList<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
    float offx = player.transform.position.x;


    int itemcount = 0;
    while (offx + generateAhead > generatedLength) {
      GameObject section = Instantiate (sectionPrefab, transform);

      section.transform.position = new Vector3 (transform.position.x + generatedLength, transform.position.y, transform.position.z);
      section.transform.rotation = transform.rotation;
      section.transform.parent = transform;

      sections.AddLast (section);


      generatedLength += sectionLength; 

      itemcount++;
      if (itemcount > 10) {
        Debug.Log ("error");
        break;
      }
    }

    itemcount = 0;
    while (sections.First.Value.transform.position.x + generateBack < offx) {
      GameObject sec = sections.First.Value;
      Destroy (sec);
      sections.RemoveFirst ();

      Debug.Log ("Removing section");

      itemcount++;
      if (itemcount > 10) {
        Debug.Log ("error2");
        break;
      }
    }

   
	}
}
