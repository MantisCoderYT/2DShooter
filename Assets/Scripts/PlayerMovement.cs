using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MoveSpeed = 1f;
    private float JumpHeight = 6;
    private float GravityScale = 1;
    private bool IsGrounded;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();

    }

    void CheckForInput()
    {
        if (IsGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // Uses Unity's Input Manager for A/D or Left/Right arrows
            rb.AddForce(new Vector2(horizontalInput * MoveSpeed, 0));
            //rb.linearVelocity = new Vector2(horizontalInput * MoveSpeed, rb.linearVelocityY);
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpHeight);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
}