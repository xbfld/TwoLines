using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shape : MonoBehaviour {
    public List<Vector2> vertices;
    public List<Edge> edges;

	// Use this for initialization
	void Awake () {
        edges = new List<Edge>();
        Debug.Log(vertices.Count);
        for (int i=0; i<vertices.Count; i++)
        {
            Vector2 start = vertices[i] + (Vector2)(gameObject.transform.position);
            Vector2 end = vertices[(i + 1) % vertices.Count] + (Vector2)(gameObject.transform.position);
            if(start.x + start.y > end.x + end.y)
            {
                Vector2 temp = start;
                start = end;
                end = temp;
            }
            if(start.x == end.x)
            {
                edges.Add(new Edge(start, end, true));
            }
            else if(start.y == end.y)
            {
                edges.Add(new Edge(start, end, false));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
