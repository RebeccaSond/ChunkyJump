using UnityEngine;

public class TeleportPlayer2D : MonoBehaviour
{
    public Transform respawnPoint;

    // This function is what helps the player teleport back to
    // the "RespawnPoint" when they "die", which is colliding
    // with the death plane or enemy objects.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            other.transform.position = respawnPoint.position;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}