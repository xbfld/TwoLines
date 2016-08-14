using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    public List<Shape> shapes;
    public List<Edge> colEdges;
    public List<Edge> rowEdges;
    public Material mat;

    // Use this for initialization
    void Awake () {
        colEdges = new List<Edge>();
        rowEdges = new List<Edge>();

        foreach(Shape s in shapes)
        {
            foreach(Edge e in s.edges)
            {
                GameObject myLine = new GameObject();
                myLine.transform.position = e.st;
                myLine.AddComponent<LineRenderer>();
                LineRenderer lr = myLine.GetComponent<LineRenderer>();
                if (e.vertical)
                {
                    colEdges.Add(e);
                    lr.gameObject.tag = "Vertical Line";
                }
                else
                {
                    rowEdges.Add(e);
                    lr.gameObject.tag = "Horizontal Line";
                }
                lr.SetColors(Color.clear, Color.clear);
                lr.SetWidth(0.0f, 0.0f);
                lr.SetPosition(0, e.st);
                lr.SetPosition(1, e.end);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
