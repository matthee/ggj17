using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct SectionDefinition {
  public GameObject Prefab;
  public float Length;
}

public class EndlessShipController : MonoBehaviour {
  public List<SectionDefinition> sectionDefinitions;

  [SerializeField]
  public SectionDefinition startSectionDefinition;

  public GameObject player;
  public float generateAhead;
  public float generateBack;

  private float generatedLength;
  private LinkedList<GameObject> sections = new LinkedList<GameObject> ();
  private bool useStartSection = true;

	// Use this for initialization
	void Start () {

	}

  public void Reset () {
    generatedLength = 0f; 

    foreach (GameObject sec in sections) {
      Destroy (sec);
    }

    sections = new LinkedList<GameObject> ();
    useStartSection = true;
  }
	
	// Update is called once per frame
	void Update () {
    float offx = player.transform.position.x;

    int itemcount = 0;
    while (offx + generateAhead > generatedLength) {
      
      SectionDefinition def;
      if (useStartSection) {
        def = startSectionDefinition;
        useStartSection = false;
      } else {
        def = sectionDefinitions [Random.Range (0, sectionDefinitions.Count)];
      }

      GameObject sectionPrefab = def.Prefab;
      GameObject section = Instantiate (sectionPrefab, transform);

      section.transform.position = new Vector3 (transform.position.x + generatedLength, transform.position.y, transform.position.z);
      section.transform.rotation = transform.rotation;
      section.transform.parent = transform;

      sections.AddLast (section);

      generatedLength += def.Length; 

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
