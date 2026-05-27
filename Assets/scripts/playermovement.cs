using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float xInput;
    public float speed;
    public float jumpForce;

    public float groundCheckRadius;
    public Transform groundCheckPosition;
    public LayerMask groundCheckLayer;
    private bool isInCutscene = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isInCutscene)
            return;

        HorizontalMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void HorizontalMovement()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // For future Rebecca: I added this to STOP that problem of
    // the rigid body fighting for control during the cutscene with the timeline. Remember this!!
    public void StartCutscene()
    {
        isInCutscene = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.simulated = false;
    }

    public void EndCutscene()
    {
        rb.simulated = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        isInCutscene = false;
    }
}

/*public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y * 0.5)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

/*
public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 7f; // Force of the jump
    public Transform groundCheck; // Reference to the ground check position
    public LayerMask groundLayer; // Ground layer mask to detect ground
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded; // Flag to check if the player is on the ground
    private float groundCheckRadius = 0.2f; // Radius of the ground check

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Get input for horizontal movement (e.g., WASD or arrow keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Handle jump input (spacebar or any other key you prefer)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // Function to make the player jump
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force upwards
    }

    /*
    [SerializeField] private float speed;
    private Rigidbody2D body;
    //private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        //Grab reference for rididbody an animator from object
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        //Code for moving player left or right
        float horizontalinput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalinput * speed,body.velocity.y);

        //flip player when moving left/right
        if (horizontalinput > 0.01f)
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        else if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);


        //Code for jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

            //Set animator parameters
            //anim.SetBool('run', horizontalinput != 0)
            //anim.SetBool("grounded", isGrounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        //anim.SetTrigger("jump");
        //grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Ground")
        //grounded = true;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    */