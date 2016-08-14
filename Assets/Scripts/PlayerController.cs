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

    Vector2 correction = 2 * Vector2.one;

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
            Vector2 pushdown = new Vector2(0, getY(c.gameObject) - getY(transform.GetChild(0)));
            Vector2 pushup = new Vector2(0, getY(c.gameObject) - getY(transform.GetChild(3)));
            correction = correction.magnitude < pushdown.magnitude ? correction : pushdown;
            correction = correction.magnitude < pushup.magnitude ? correction : pushup;
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("Vertical Line"))
        {
            Debug.Log("Vertical ENT");
            walled = true;
            leftWalled = c.gameObject.transform.position.x > transform.position.x;
            rightWalled = !leftWalled;
            LineManager l = GameObject.FindObjectOfType<LineManager>();

            Vector2 pushleft = new Vector2(getX(c.gameObject) - getX(transform.GetChild(3)),0);
            Vector2 pushright = new Vector2(getX(c.gameObject) - getX(transform.GetChild(0)),0);
            correction = correction.magnitude < pushleft.magnitude ? correction : pushleft;
            correction = correction.magnitude < pushright.magnitude ? correction : pushright;

            if (portable)
            {
                GameObject pair = l.EnterOnRight(c.gameObject, getY(transform.GetChild(0)), getY(transform.GetChild(3)));
            }
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

    public static bool isAscOrder(float a, float b, float c)
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
        if (correction.magnitude < Vector2.one.magnitude)
        {
            transform.position += new Vector3(correction.x, correction.y);
        }
        float h = Input.GetAxisRaw("Horizontal");
        float xv = h * xSpeed;
        float yv = rb2d.velocity.y - Time.deltaTime * gravity;
        GameObject[] hline = GameObject.FindGameObjectsWithTag("Horizontal Line");
        GameObject[] vline = GameObject.FindGameObjectsWithTag("Vertical Line");
        Debug.Log(transform.childCount);
        Transform p_tl = transform.GetChild(0);
        Transform p_tr = transform.GetChild(1);
        Transform p_bl = transform.GetChild(2);
        Transform p_br = transform.GetChild(3);
        bl = null;
        br = null;
        rt = null;
        rb = null;
        foreach (var item in hline) // for all hline
        {
            Debug.Log(item.transform.childCount);
            float y = item.transform.position.y;
            Debug.Log(item.transform.GetChild(0));
            float left = item.transform.GetChild(0).position.x;
            float right = item.transform.GetChild(1).position.x;

            if (isAscOrder((bl ? getY(bl) : Mathf.NegativeInfinity), y, getY(p_bl)) &&
                isAscOrder(left, getX(p_bl), right))
            {
                bl = item.gameObject;
            }
            if (isAscOrder((br ? getY(br) : Mathf.NegativeInfinity), y, getY(p_br)) &&
                isAscOrder(left, getX(p_br), right))
            {
                br = item.gameObject;
            }

        }
        foreach (var item in vline)
        {
            float x = item.transform.position.x;
            float top = item.transform.GetChild(0).position.y;
            float bottom = item.transform.GetChild(1).position.y;

            if (isAscOrder((rt ? getX(rt) : Mathf.NegativeInfinity), x, getX(p_tr)) &&
                isAscOrder(bottom, getY(p_tr), top))
            {
                rt = item.gameObject;
            }
            if (isAscOrder((rb ? getX(rb) : Mathf.NegativeInfinity), x, getX(p_tr)) &&
                isAscOrder(bottom, getY(p_tr), top))
            {
                rb = item.gameObject;
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
