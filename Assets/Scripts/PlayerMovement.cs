using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MoveSpeed = 6;
    private float JumpHeight = 5;
    private float GravityScale = 1;
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
        float horizontalInput = Input.GetAxis("Horizontal"); // Uses Unity's Input Manager for A/D or Left/Right arrows
        rb.linearVelocity = new Vector2(horizontalInput * MoveSpeed, rb.linearVelocityY);
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpHeight);
        }
    }
}
