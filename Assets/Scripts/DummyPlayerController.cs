using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    bool facingRight = true;
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
            if (facingRight)
            {
                Flip();
            }
            TryLeftward();
            left_pressed = -1;
        }
        if (right_pressed == 1)
        {
            if (!facingRight)
            {
                Flip();
            }
            TryRightward();
            right_pressed = -1;
        }
        if (up_pressed == 1)
        {
            TryUpward();
            up_pressed = -1;
        }
        if (down_pressed == 1)
        {
            TryDownward();
            down_pressed = -1;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Extend(Vector3 center, Vector3 scaler)
    {
        transform.position += Vector3.Scale(center, transform.localScale);
        transform.localScale = scaler;
        transform.position -= Vector3.Scale(center, scaler);
    }
    void Vextend(Vector3 center, float vscaler)
    {
        Vector3 s = new Vector3(transform.localScale.x, vscaler, transform.localScale.z);
        transform.position += Vector3.Scale(center, transform.localScale);
        transform.localScale = s;
        transform.position -= Vector3.Scale(center, s);
    }
    void Hextend(Vector3 center, float hscaler)
    {
        Vector3 s = new Vector3(hscaler, transform.localScale.y, transform.localScale.z);
        transform.position += Vector3.Scale(center, transform.localScale);
        transform.localScale = s;
        transform.position -= Vector3.Scale(center, s);
    }
    void TryVertical(int direction)
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
        int top_nearest_x2 = direction * int.MaxValue;
        int bottom_nearest_x2 = direction * int.MaxValue;
        int top_nearest2_x2 = direction * int.MaxValue;
        int bottom_nearest2_x2 = direction * int.MaxValue;
        foreach (var item in vline)
        {
            float _x = item.transform.position.x;
            float _top = map.colEdges[item.GetComponent<LineRenderer>()].end.y;
            float _bottom = map.colEdges[item.GetComponent<LineRenderer>()].st.y;
            int _x2 = Mathf.RoundToInt(_x * 2);
            int _top2 = Mathf.RoundToInt(_top * 2);
            int _bottom2 = Mathf.RoundToInt(_bottom * 2);

            if ((direction * x2 <= direction * _x2 && direction * _x2 < direction * top_nearest_x2) &&
                (_bottom2 < top2 && top2 <= _top2))
            {
                top_nearest = item.GetComponent<LineRenderer>();
                top_nearest_x2 = _x2;
            }
            if ((direction * x2 <= direction * _x2 && direction * _x2 < direction * bottom_nearest_x2) &&
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

            if ((direction * top_nearest_x2 < direction * _x2 && direction * _x2 < direction * top_nearest2_x2) &&
                (_bottom2 < top2 && top2 <= _top2))
            {
                top_nearest2 = item.GetComponent<LineRenderer>() ;
                top_nearest2_x2 = _x2;
            }
            if ((direction * bottom_nearest_x2 < direction * _x2 && direction * _x2 < direction * bottom_nearest2_x2) &&
                (_bottom2 <= bottom2 && bottom2 < _top2))
            {
                bottom_nearest2 = item.GetComponent<LineRenderer>();
                bottom_nearest2_x2 = _x2;
            }
        }
        // none
        if (!top_nearest && !bottom_nearest)
        {
            transform.position += direction * Vector3.right;
            if (vextend)
            {
                Hextend(Vector3.right / 2, direction);
                vextend = false;
            }
        }
        else if (direction * x2 + 2 <= Mathf.Min(direction * top_nearest_x2, direction * bottom_nearest_x2))
        {
            transform.position += direction * Vector3.right;
            if (vextend)
            {
                Hextend(Vector3.right / 2, direction);
                vextend = false;
            }
        }
        // both are same line
        else if (top_nearest2 && bottom_nearest2 &&
            top_nearest == bottom_nearest &&
            top_nearest2 == bottom_nearest2)
        {
            transform.position += direction * Vector3.right;
            if (vextend)
            {
                Hextend(Vector3.right / 2, direction);
                vextend = false;
            }
            transform.position += new Vector3((top_nearest2_x2 - top_nearest_x2) / 2.0f, 0);
            Debug.Log((top_nearest2_x2 - top_nearest_x2) / 2.0f);
            if (direction * top_nearest2_x2 > direction * Mathf.RoundToInt(transform.GetChild(0).position.x * 2))
            {
                Hextend(Vector3.right / 2, direction * 1 + (top_nearest2_x2 - top_nearest_x2) / 2.0f);
                vextend = true;
            }
        }
    }
    void TryHorizontal(int direction)
    {

        float y = transform.GetChild(1).position.y;
        float left = transform.GetChild(0).position.x;
        float right = transform.GetChild(1).position.x;
        int y2 = Mathf.RoundToInt(y * 2);
        int left2 = Mathf.RoundToInt(left * 2);
        int right2 = Mathf.RoundToInt(right * 2);
        GameObject[] hline = GameObject.FindGameObjectsWithTag("Horizontal Line");
        GameObject left_nearest = null;
        GameObject right_nearest = null;
        GameObject left_nearest2 = null;
        GameObject right_nearest2 = null;
        int left_nearest_y2 = direction * int.MaxValue;
        int right_nearest_y2 = direction * int.MaxValue;
        int left_nearest2_y2 = direction * int.MaxValue;
        int right_nearest2_y2 = direction * int.MaxValue;
        foreach (var item in hline)
        {
            float _y = item.transform.position.y;
            float _left = item.transform.GetChild(0).position.x;
            float _right = item.transform.GetChild(1).position.x;
            int _y2 = Mathf.RoundToInt(_y * 2);
            int _left2 = Mathf.RoundToInt(_left * 2);
            int _right2 = Mathf.RoundToInt(_right * 2);

            if ((direction * y2 <= direction * _y2 && direction * _y2 < direction * right_nearest_y2) &&
                (_left2 < right2 && right2 <= _right2))
            {
                right_nearest = item;
                right_nearest_y2 = _y2;
            }
            if ((direction * y2 <= direction * _y2 && direction * _y2 < direction * left_nearest_y2) &&
                (_left2 <= left2 && left2 < _right2))
            {
                left_nearest = item;
                left_nearest_y2 = _y2;
            }
        }
        foreach (var item in hline)
        {
            float _y = item.transform.position.y;
            float _left = item.transform.GetChild(0).position.x;
            float _right = item.transform.GetChild(1).position.x;
            int _y2 = Mathf.RoundToInt(_y * 2);
            int _left2 = Mathf.RoundToInt(_left * 2);
            int _right2 = Mathf.RoundToInt(_right * 2);

            if ((direction * right_nearest_y2 < direction * _y2 && direction * _y2 < direction * right_nearest2_y2) &&
                (_left2 < right2 && right2 <= _right2))
            {
                right_nearest2 = item;
                right_nearest2_y2 = _y2;
            }
            if ((direction * left_nearest_y2 < direction * _y2 && direction * _y2 < direction * left_nearest2_y2) &&
                (_left2 <= left2 && left2 < _right2))
            {
                left_nearest2 = item;
                left_nearest2_y2 = _y2;
            }
        }
        // none
        if (!right_nearest && !left_nearest)
        {
            transform.position += direction * Vector3.up;
            if (hextend)
            {
                Vextend(Vector3.up / 2, 1);
                hextend = false;
            }
        }
        else if (direction * y2 + 2 <= Mathf.Min(direction * right_nearest_y2, direction * left_nearest_y2))
        {
            transform.position += direction * Vector3.up;
            if (hextend)
            {
                Vextend(Vector3.up / 2, 1);
                hextend = false;
            }
        }
        // both are same line
        else if (right_nearest2 && left_nearest2 &&
            right_nearest == left_nearest &&
            right_nearest2 == left_nearest2)
        {
            transform.position += direction * Vector3.up;
            if (hextend)
            {
                Vextend(Vector3.up / 2, 1);
                hextend = false;
            }
            transform.position += new Vector3(0, (right_nearest2_y2 - right_nearest_y2) / 2.0f);
            Debug.Log((right_nearest2_y2 - right_nearest_y2) / 2.0f);
            if (direction * right_nearest2_y2 > direction * Mathf.RoundToInt(transform.GetChild(direction+1).position.y * 2))
            {
                Vextend(Vector3.up / 2, 1 + (right_nearest2_y2 - right_nearest_y2) / 2.0f);
                hextend = true;
            }
        }
    }
    void TryLeftward()
    {
        TryVertical(-1);
    }
    void TryRightward()
    {
        TryVertical(1);
    }
    void TryUpward()
    {
        TryHorizontal(1);
    }
    void TryDownward()
    {
        TryHorizontal(-1);
    }
}
