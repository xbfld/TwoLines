using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 어떻게 할까:
// gamecontroller한테 player의 위치를 넘겨서, 플레이어와 벽이 충돌한 두 점을 보내서,
//vertical이랑 부딪힌 거면 y값 고정하고 쭉 돌려서 진행방향의 가장 가까운 collider가 다 같은지 본다.
public class PlayerController : MonoBehaviour
{
    public float gravity = 10f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;

    bool grounded = false;
    bool jump = false;
    bool facingRight = true;

    public GameController gameController;

    public Rigidbody2D rb2d;

    ArrayList horizontal_line = new ArrayList();
    ArrayList vertical_line = new ArrayList();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Horizontal Line"))
        {
            {
                grounded = true;
            }
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("Horizontal Line"))
        {
            horizontal_line.Add(c);
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("Vertical Line"))
        {
            vertical_line.Add(c);

            // 퉁과 못 하는 box라면 x축 velocity를 0으로 해서 못 들어가게 막아야 함.
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
        // TODO: do something with horizontal_line and vertical_line

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
