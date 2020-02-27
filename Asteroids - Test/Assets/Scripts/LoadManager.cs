using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}