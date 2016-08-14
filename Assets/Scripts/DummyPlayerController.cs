using UnityEngine;
using System.Collections;

public class DummyPlayerController : MonoBehaviour
{
    public Map map;
    // 0 not pressed, 1 pressed, -1 recently pressed
    int left_pressed = 0;
    int right_pressed = 0;
    int up_pressed = 0;
    int down_pressed = 0;
    bool vextend = false;
    bool hextend = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //#region Input management
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0)
        {
            if (left_pressed == 0)
            {
                left_pressed = 1;
                right_pressed = 0;
            }
        }
        else if (h > 0)
        {
            if (right_pressed == 0)
            {
                left_pressed = 0;
                right_pressed = 1;
            }
        }
        else
        {
            left_pressed = 0;
            right_pressed = 0;
        }
        float v = Input.GetAxisRaw("Vertical");
        if (v < 0)
        {
            if (down_pressed == 0)
            {
                down_pressed = 1;
                up_pressed = 0;
            }
        }
        else if (v > 0)
        {
            if (up_pressed == 0)
            {
                down_pressed = 0;
                up_pressed = 1;
            }
        }
        else
        {
            down_pressed = 0;
            up_pressed = 0;
        }
        //#endregion

        if (left_pressed == 1)
        {
            transform.position += Vector3.left;
            left_pressed = -1;
        }
        if (right_pressed == 1)
        {
            TryRightward();
            right_pressed = -1;
        }
        if (up_pressed == 1)
        {
            transform.position += Vector3.up;
            up_pressed = -1;
        }
        if (down_pressed == 1)
        {
            transform.position += Vector3.down;
            down_pressed = -1;
        }
    }
    void Extend(Vector3 center, Vector3 scaler)
    {
        transform.position += Vector3.Scale(center, transform.localScale);
        transform.localScale = scaler;
        transform.position -= Vector3.Scale(center, scaler);
    }
    void TryRightward()
    {
        float x = transform.GetChild(3).position.x;
        float top = transform.GetChild(1).position.y;
        float bottom = transform.GetChild(3).position.y;
        int x2 = Mathf.RoundToInt(x * 2);
        int top2 = Mathf.RoundToInt(top * 2);
        int bottom2 = Mathf.RoundToInt(bottom * 2);
        GameObject[] vline = GameObject.FindGameObjectsWithTag("Vertical Line");
        LineRenderer top_nearest = null;
        LineRenderer bottom_nearest = null;
        LineRenderer top_nearest2 = null;
        LineRenderer bottom_nearest2 = null;
        int top_nearest_x2 = int.MaxValue;
        int bottom_nearest_x2 = int.MaxValue;
        int top_nearest2_x2 = int.MaxValue;
        int bottom_nearest2_x2 = int.MaxValue;
        foreach (var item in vline)
        {
            float _x = item.transform.position.x;
            float _top = map.colEdges[item.GetComponent<LineRenderer>()].end.y;
            float _bottom = map.colEdges[item.GetComponent<LineRenderer>()].st.y;
            int _x2 = Mathf.RoundToInt(_x * 2);
            int _top2 = Mathf.RoundToInt(_top * 2);
            int _bottom2 = Mathf.RoundToInt(_bottom * 2);

            if ((x2 <= _x2 && _x2 < top_nearest_x2) &&
                (_bottom2 < top2 && top2 <= _top2))
            {
                top_nearest = item.GetComponent<LineRenderer>();
                top_nearest_x2 = _x2;
            }
            if ((x2 <= _x2 && _x2 < bottom_nearest_x2) &&
                (_bottom2 <= bottom2 && bottom2 < _top2))
            {
                bottom_nearest = item.GetComponent<LineRenderer>();
                bottom_nearest_x2 = _x2;
            }
        }
        foreach (var item in vline)
        {

            float _x = item.transform.position.x;
            float _top = map.colEdges[item.GetComponent<LineRenderer>()].end.y;
            float _bottom = map.colEdges[item.GetComponent<LineRenderer>()].st.y;
            int _x2 = Mathf.RoundToInt(_x * 2);
            int _top2 = Mathf.RoundToInt(_top * 2);
            int _bottom2 = Mathf.RoundToInt(_bottom * 2);

            if ((top_nearest_x2 < _x2 && _x2 < top_nearest2_x2) &&
                (_bottom2 < top2 && top2 <= _top2))
            {
                top_nearest2 = item.GetComponent<LineRenderer>();
                top_nearest2_x2 = _x2;
            }
            if ((top_nearest_x2 < _x2 && _x2 < bottom_nearest2_x2) &&
                (_bottom2 <= bottom2 && bottom2 < _top2))
            {
                bottom_nearest2 = item.GetComponent<LineRenderer>();
                bottom_nearest2_x2 = _x2;
            }
        }
        // none
        if (!top_nearest && !bottom_nearest)
        {
            transform.position += Vector3.right;
            if (vextend)
            {
                Extend(Vector3.right / 2, Vector3.one);
                vextend = false;
            }
        }
        // one of them are none
        //else if (top_nearest ^ bottom_nearest)
        //{
        //    return;
        //}
        // both are far enough
        else if (x2 + 2 <= Mathf.Min(top_nearest_x2, bottom_nearest_x2))
        {
            transform.position += Vector3.right;
            if (vextend)
            {
                Extend(Vector3.right / 2, Vector3.one);
                vextend = false;
            }
        }
        // both are same line
        else if (top_nearest2 && bottom_nearest2 &&
            top_nearest == bottom_nearest &&
            top_nearest2 == bottom_nearest2)
        {
            transform.position += Vector3.right;
            if (vextend)
            {
                Extend(Vector3.right / 2, Vector3.one);
                vextend = false;
            }
            transform.position += new Vector3((top_nearest2_x2 - top_nearest_x2) / 2.0f, 0);
            if (top_nearest2_x2 > Mathf.RoundToInt(transform.GetChild(0).position.x * 2))
            {
                Extend(Vector3.right / 2, new Vector3(1 + (top_nearest2_x2 - top_nearest_x2) / 2.0f, 1, 1));
                vextend = true;
            }
        }
    }
}
