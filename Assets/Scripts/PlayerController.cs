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
