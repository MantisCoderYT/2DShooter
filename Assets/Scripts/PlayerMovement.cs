using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MoveSpeed = 1000f;
    private float JumpHeight = 10f;
    private float GravityScale = 2f;
    [SerializeField]
    private bool IsGrounded;
    private float GroundedDampening = 5f;
    private float maxAngularVelocity = 2000f;
    private Rigidbody2D rb;
    private LifeSystem lifeSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
        rb.gravityScale = GravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lifeSystem.IsDead)
        {
            CheckForInput();
        }
         rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
        
    }    

    void CheckForInput()
    {
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

    public void Grounded()
    {
        IsGrounded = true;
    }

    public void Ungrounded()
    {
        IsGrounded = false;
    }

    public void Respawn()
    {
        rb.Sleep();
        transform.position = new Vector2(12, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}