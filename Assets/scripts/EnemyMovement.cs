using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 3f;

    [SerializeField] private int startDirection = 1;

    private int currentDirection;
    private float halfWidth;
    private Vector2 movement;

    private void Start()
    {
        halfWidth = spriteRenderer.bounds.extents.x;
        currentDirection = startDirection;
    }

    private void FixedUpdate()
    {
        movement.x = speed * currentDirection;
        movement.y = rigidBody.linearVelocity.y;
        rigidBody.linearVelocity = movement;
        SetDirection();
    }

    private void SetDirection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * currentDirection, halfWidth + 0.1f, LayerMask.GetMask("TurnPoint"));
        if (hit.collider != null)
        {
            currentDirection *= -1;
            spriteRenderer.flipX = currentDirection < 0;
        }
    }
}