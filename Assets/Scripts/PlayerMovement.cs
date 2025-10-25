using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MoveSpeed = 2000f;
    private float JumpHeight = 8f;
    private float GravityScale = 2f;
    private bool IsGrounded;
    private float GroundedDampening = 8f;
    private float maxAngularVelocity = 300f;
    private bool IsDead;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GravityScale;
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            CheckForInput();
        }
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
                rb.angularDamping = GroundedDampening;
                float horizontalInput = -1.0f * Input.GetAxis("Horizontal"); // Uses Unity's Input Manager for A/D or Left/Right arrows
                rb.AddTorque(horizontalInput * MoveSpeed * Time.deltaTime, 0);
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpHeight);
                }
            }
            else
            {
               rb.angularDamping = 0f;
            }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||collision.gameObject.tag == "Object")
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||collision.gameObject.tag == "Object")
        {
            IsGrounded = false;
        }
    }
}