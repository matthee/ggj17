using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnim : MonoBehaviour {

  public float width = 100;
  public float height = 100; 
  public int widthNodes = 1000;
  public int heightNodes = 100;

  private Mesh m_Mesh;
   
  private float m_Time; 

  private int nodeCount;

	void Start () {
    m_Mesh = new Mesh();
    m_Time = 0f; 

    nodeCount = widthNodes * heightNodes;


    Vector3[] vertices = new Vector3 [nodeCount];
    Vector2[] uvMap = new Vector2[nodeCount];
    
    int triangle = 0;
    int[] triangles = new int[ (widthNodes - 1) * (heightNodes - 1) * 2 * 3];

    for (int z = 0; z < heightNodes; z++) {
      for (int x = 0; x < widthNodes; x++) {
        int i = z * widthNodes + x;
        vertices [i] = new Vector3 (0, 0, 0);

        if (z > 0) {
          if (x > 0) {
            triangles [triangle++] = z * widthNodes + x;
            triangles [triangle++] = (z - 1) * widthNodes + x - 1;
            triangles [triangle++] = z * widthNodes + x - 1;

            triangles [triangle++] = z * widthNodes + x;
            triangles [triangle++] = (z - 1) * widthNodes + x;
            triangles [triangle++] = (z - 1) * widthNodes + x - 1;
          }
        }
      }
    }

    m_Mesh.vertices = vertices;
    m_Mesh.triangles = triangles;

    GetComponent<MeshFilter> ().mesh = m_Mesh;
	}
	
	// Update is called once per frame
	void Update () {
    m_Time += Time.deltaTime;
    
    float widthIncrement = width / widthNodes;
    float heightIncrement = height / heightNodes;

    Vector3[] vertices = m_Mesh.vertices;

    for (int z = 0; z < heightNodes; z++) {
      for (int x = 0; x < widthNodes; x++) {
        int i = z * widthNodes + x;

        float p = x + m_Time;
        vertices[i] = new Vector3(x * widthIncrement, Mathf.Sin(p * 0.3f)/0.3f, z * heightIncrement);
      }
    }

    m_Mesh.vertices = vertices;
	}
}
