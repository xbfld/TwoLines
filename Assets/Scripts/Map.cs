using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    public List<Shape> shapes;
    public Dictionary<LineRenderer, Edge> colEdges;
    public Dictionary<LineRenderer, Edge> rowEdges;
    public Material mat;

    // Use this for initialization
    void Start () {
        colEdges = new Dictionary<LineRenderer, Edge>();
        rowEdges = new Dictionary<LineRenderer, Edge>();

        foreach (Shape s in shapes)
        {
            foreach(Edge e in s.edges)
            {
                GameObject myLine = new GameObject();
                myLine.transform.position = e.st;
                myLine.AddComponent<LineRenderer>();
                LineRenderer lr = myLine.GetComponent<LineRenderer>();
                lr.SetColors(Color.clear, Color.red);
                lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
                lr.SetWidth(0.0f, 0.0f);
                lr.SetPosition(0, e.st);
                lr.SetPosition(1, e.end);
                if (e.vertical)
                {
                    colEdges[lr] = e;
                    lr.gameObject.tag = "Vertical Line";
                }
                else
                {
                    rowEdges[lr] = e;
                    lr.gameObject.tag = "Horizontal Line";
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
