using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Vector2 spawnPosition;

    void OnLevelWasLoaded(int level)
    {
        if (level == SceneManager.GetActiveScene().buildIndex)
        {
            transform.position = spawnPosition;
        }
    }
}