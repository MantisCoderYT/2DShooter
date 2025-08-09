using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MoveSpeed = 3000f;
    private float JumpHeight = 6f;
    private float GravityScale = 1f;
    private bool IsGrounded;
    private float maxAngularVelocity = 400f;
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
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);

    }

    void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.Sleep();
            transform.position = new Vector2(0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (IsGrounded)
            {
                float horizontalInput = -1.0f * Input.GetAxis("Horizontal"); // Uses Unity's Input Manager for A/D or Left/Right arrows
                rb.AddTorque(horizontalInput * MoveSpeed * Time.deltaTime, 0);
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