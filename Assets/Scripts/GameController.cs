using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// sort col/row...?

public class GameController : MonoBehaviour {

    public Box[] boxes;
    public List<EdgeCollider2D> collines;
    public List<EdgeCollider2D> rowlines;

    // each endpoints of the edge colliders:
    // let that edge EdgeCollider2D b.
    // b.transform.parent.GetComponent<Renderer>().bounds.center + b.transform.parent.GetComponent<Renderer>().bounds.size * b.points(elem.wise product).
    // 가 답이다. 이걸 써서 점으로부터 선을 그어서 그 edge 위에 있는지 없는지 알 수 있다.

    // Use this for initialization
    void Start () {
        collines = new List<EdgeCollider2D>();
        rowlines = new List<EdgeCollider2D>();
        foreach (Box b in boxes)
        {
            collines.Add(b.Left);
            rowlines.Add(b.Bottom);
            collines.Add(b.Left);
            rowlines.Add(b.Top);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

}
