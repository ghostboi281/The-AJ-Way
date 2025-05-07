using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool jump;

    void Awake()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal/vertical movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Apply jump force
        if (jump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jump = false;
        }
    }
}
