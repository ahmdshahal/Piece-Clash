using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Fungsi restart game
    /// </summary>
    public void Retry()
    {
        //Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Fungsi memulai game
    /// </summary>
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseOrResume(int value)
    {
        Time.timeScale = value;
    }
}
