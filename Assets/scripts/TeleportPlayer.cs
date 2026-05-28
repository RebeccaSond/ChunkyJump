using UnityEngine;

public class TeleportPlayer2D : MonoBehaviour
{
    public Transform respawnPoint;

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