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

    // This function grabs and stores the Rigidbody to use later.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // This function helps control the jumping of the player as well as
    // allowing when the player is able to move after the intro cutscene.
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

    // This function is the magic of the player being able to move back and forth.
    void HorizontalMovement()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
    }

    // This function helps check if the player is on the ground so it knows
    // when to allow the player the ability to jump
    bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheckPosition.position, new Vector2(0.6f, 0.1f), 0f, Vector2.down, groundCheckRadius, groundCheckLayer);
    }

    // This function is the magic for jumping as the player.
    // This function is called in the "Update" function.
    void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // For future Rebecca: I added these two functions to STOP the problem of
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