using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float gravity = 10f;
    public float xSpeed = 10f;
    public float maxSpeed = 100f;
    public float jumpForce = 100f;

    bool grounded = false;
    bool jump = false;
    bool facingRight = true;
    bool walled = false;
    bool leftWalled = false;
    bool rightWalled = false;
    bool portable = false;

    public Rigidbody2D rb2d;
    /// <summary>
    /// linecast direction
    ///    tl  tr
    /// lt r - ㄱ rt
    /// lb ㄴㅡㅢ rb
    ///    bl  br
    /// </summary>
    GameObject tl, tr, bl, br, lt, lb, rt, rb;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Horizontal Line"))
        {
            Debug.Log("Horizontal ENT");
            grounded = true;
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("Vertical Line"))
        {
            Debug.Log("Vertical ENT");
            walled = true;
            leftWalled = c.gameObject.transform.position.x > transform.position.x;
            rightWalled = !leftWalled;
        }
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Horizontal Line"))
        {
            Debug.Log("Horizontal EXT");
            grounded = false;
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("Vertical Line"))
        {
            Debug.Log("Vertical EXT");
            walled = false;
            leftWalled = false;
            rightWalled = false;
        }
    }
    float getX(Transform t)
    {
        return t.position.x;
    }
    float getX(GameObject g)
    {
        return getX(g.transform);
    }
    float getY(Transform t)
    {
        return t.position.y;
    }
    float getY(GameObject g)
    {
        return getY(g.transform);
    }

    bool isAscOrder(float a, float b, float c)
    {
        return a < b && b < c;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Jump");
            jump = true;
        }
        if (Input.GetButtonDown("Fire1") && walled)
        {
            Debug.Log("Fire1");
            portable = true;
        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float xv = h * xSpeed;
        float yv = rb2d.velocity.y - Time.deltaTime * gravity;
        GameObject[] hline = GameObject.FindGameObjectsWithTag("Horizontal Line");
        Transform p_tl = transform.GetChild(0);
        Transform p_tr = transform.GetChild(1);
        Transform p_bl = transform.GetChild(2);
        Transform p_br = transform.GetChild(3);
        bl = null;
        br = null;
        foreach (var item in hline) // for all hline
        {
            float y = item.transform.position.y;
            float left = item.transform.GetChild(0).position.x;
            float right = item.transform.GetChild(1).position.x;

            if (isAscOrder((bl ? getY(bl) : Mathf.NegativeInfinity), y, getY(p_bl)) &&
                isAscOrder(left, getX(p_bl), right))
            {
                bl = item.gameObject;
            }
            if (isAscOrder((br ? getY(bl) : Mathf.NegativeInfinity), y, getY(p_br)) &&
                isAscOrder(left, getX(p_br), right))
            {
                br = item.gameObject;
            }

            if (isAscOrder((br ? getY(bl) : Mathf.NegativeInfinity), y, getY(p_br)) &&
                isAscOrder(left, getX(p_br), right))
            {
                br = item.gameObject;
            }

        }
        if (grounded)
        {
            yv = 0;
        }

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            yv = jumpForce;
            jump = false;
            grounded = false;
        }
        xv = Mathf.Clamp(xv, -maxSpeed, maxSpeed);
        yv = Mathf.Clamp(yv, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(xv, yv);
        //Debug.Log(rb2d.velocity);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
