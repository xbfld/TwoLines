using UnityEngine;
using System.Collections;

public class Edge{

    public Vector2 st;
    public Vector2 end;
    public bool vertical;

    public Edge(Vector2 st, Vector2 end, bool vertical)
    {
        this.st = st;
        this.end = end;
        this.vertical = vertical;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
