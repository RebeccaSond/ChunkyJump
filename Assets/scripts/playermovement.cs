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
        return Physics2D.BoxCast(groundCheckPosition.position, new Vector2(0.6f, 0.1f), 0f, Vector2.down, groundCheckRadius, groundCheckLayer);
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