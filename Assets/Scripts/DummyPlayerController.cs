using UnityEngine;
using System.Collections;

public class DummyPlayerController : MonoBehaviour
{
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
            if(facingRight)
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
            transform.position += Vector3.up;
            up_pressed = -1;
        }
        if (down_pressed == 1)
        {
            transform.position += Vector3.down;
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
    void TryVertical(int direction)
    {
        float x = transform.GetChild(3).position.x;
        float top = transform.GetChild(1).position.y;
        float bottom = transform.GetChild(3).position.y;
        int x2 = Mathf.RoundToInt(x * 2);
        int top2 = Mathf.RoundToInt(top * 2);
        int bottom2 = Mathf.RoundToInt(bottom * 2);
        GameObject[] vline = GameObject.FindGameObjectsWithTag("Vertical Line");
        GameObject top_nearest = null;
        GameObject bottom_nearest = null;
        GameObject top_nearest2 = null;
        GameObject bottom_nearest2 = null;
        int top_nearest_x2 = direction * int.MaxValue;
        int bottom_nearest_x2 = direction * int.MaxValue;
        int top_nearest2_x2 = direction * int.MaxValue;
        int bottom_nearest2_x2 = direction * int.MaxValue;
        foreach (var item in vline)
        {
            float _x = item.transform.position.x;
            float _top = item.transform.GetChild(0).position.y;
            float _bottom = item.transform.GetChild(1).position.y;
            int _x2 = Mathf.RoundToInt(_x * 2);
            int _top2 = Mathf.RoundToInt(_top * 2);
            int _bottom2 = Mathf.RoundToInt(_bottom * 2);

            if ((direction*x2 <= direction*_x2 && direction*_x2 < direction * top_nearest_x2) &&
                (_bottom2 < top2 && top2 <= _top2))
            {
                top_nearest = item;
                top_nearest_x2 = _x2;
            }
            if ((direction * x2 <= direction * _x2 && direction * _x2 < direction * bottom_nearest_x2) &&
                (_bottom2 <= bottom2 && bottom2 < _top2))
            {
                bottom_nearest = item;
                bottom_nearest_x2 = _x2;
            }
        }
        foreach (var item in vline)
        {

            float _x = item.transform.position.x;
            float _top = item.transform.GetChild(0).position.y;
            float _bottom = item.transform.GetChild(1).position.y;
            int _x2 = Mathf.RoundToInt(_x * 2);
            int _top2 = Mathf.RoundToInt(_top * 2);
            int _bottom2 = Mathf.RoundToInt(_bottom * 2);

            if ((direction * top_nearest_x2 < direction * _x2 && direction * _x2 < direction * top_nearest2_x2) &&
                (_bottom2 < top2 && top2 <= _top2))
            {
                top_nearest2 = item;
                top_nearest2_x2 = _x2;
            }
            if ((direction * bottom_nearest_x2 < direction * _x2 && direction * _x2 < direction * bottom_nearest2_x2) &&
                (_bottom2 <= bottom2 && bottom2 < _top2))
            {
                bottom_nearest2 = item;
                bottom_nearest2_x2 = _x2;
            }
        }
        // none
        if (!top_nearest && !bottom_nearest)
        {
            transform.position += direction * Vector3.right;
            if (vextend)
            {
                Extend(Vector3.right / 2, new Vector3(direction,1,1));
                vextend = false;
            }
        }
        else if (direction * x2 + 2 <=  Mathf.Min(direction * top_nearest_x2, direction * bottom_nearest_x2))
        {
            transform.position += direction * Vector3.right;
            if (vextend)
            {
                Extend(Vector3.right / 2, new Vector3(direction, 1, 1));
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
                Extend(Vector3.right / 2, new Vector3(direction, 1, 1));
                vextend = false;
            }
            transform.position += new Vector3((top_nearest2_x2 - top_nearest_x2) / 2.0f, 0);
            Debug.Log((top_nearest2_x2 - top_nearest_x2) / 2.0f);
            if (direction * top_nearest2_x2 > direction * Mathf.RoundToInt(transform.GetChild(0).position.x * 2))
            {
                Extend(Vector3.right / 2, new Vector3(direction*1 + (top_nearest2_x2 - top_nearest_x2) / 2.0f, 1, 1));
                vextend = true;
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
}
