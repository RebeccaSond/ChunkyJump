using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    // This function calls the other C# script called "SceneController" and
    // helps set motion to changing the scenes upon colliding
    // with the Becca sprite.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }
}
