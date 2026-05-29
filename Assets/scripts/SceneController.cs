using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    // This function is making sure that only one SceneController instance exists to prevent duplication.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestoryOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // This function is what helps load the next scene in the build settings.
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This function loads a scene by its name.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
