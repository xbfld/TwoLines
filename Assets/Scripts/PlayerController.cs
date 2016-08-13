using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float gravity = 10f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;

    bool grounded = false;
    bool jump = false;
    bool facingRight = true;

    public Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Horizontal Line"))
        {
            grounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Horizontal Line"))
        {
            grounded = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float xv = h * maxSpeed;
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
        }
        xv = Mathf.Clamp(xv, -maxSpeed, maxSpeed);
        yv = Mathf.Clamp(yv, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(xv, yv);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
