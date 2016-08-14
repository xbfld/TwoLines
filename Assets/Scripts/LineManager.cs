using UnityEngine;
using System.Collections;

public class LineManager : MonoBehaviour
{

    GameObject enterLine;
    GameObject pairLine;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject EnterOnRight(GameObject line, float top, float bottom)
    {
        float x = line.transform.position.x;
        GameObject[] vline = GameObject.FindGameObjectsWithTag("Vertical Line");
        GameObject top_nearest = null;
        float top_nearest_x = Mathf.Infinity;
        GameObject bottom_nearest = null;
        float bottom_nearest_x = Mathf.Infinity;
        foreach (var item in vline)
        {
            float _x = item.transform.position.x;
            float _top = item.transform.GetChild(0).position.y;
            float _bottom = item.transform.GetChild(1).position.y;
            if (PlayerController.isAscOrder(x, _x, top_nearest_x) &&
                PlayerController.isAscOrder(_bottom, top, _top))
            {
                top_nearest = item;
                top_nearest_x = _x;
            }
            if (PlayerController.isAscOrder(x, _x, bottom_nearest_x) &&
                PlayerController.isAscOrder(_bottom, bottom, _top))
            {
                bottom_nearest = item;
                bottom_nearest_x = _x;
            }
        }
        if (top_nearest && bottom_nearest && top_nearest == bottom_nearest)
        {
            int mask = (1 << LayerMask.NameToLayer("Vertical Line")) | (1 << LayerMask.NameToLayer("Horizontal Line"));
            if(Physics2D.OverlapArea(new Vector2(x+0.1f, bottom), new Vector2(top_nearest_x-0.1f, top), mask))
            {
                Debug.Log(Physics2D.OverlapArea(new Vector2(x, bottom), new Vector2(top_nearest_x, top), mask));
                return null;
            }
            else
            {
                Debug.Log(2);
                enterLine = line;
                pairLine = top_nearest;
                enterLine.GetComponent<BoxCollider2D>().enabled = false;
                pairLine.GetComponent<BoxCollider2D>().enabled = false;

                return top_nearest;
            }
        }
        else
        {
                Debug.Log(3);
            return null;
        }
    }
}
