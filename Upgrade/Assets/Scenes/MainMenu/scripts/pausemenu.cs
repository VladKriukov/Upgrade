using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool gameispaused = false;
    public GameObject pausemenuui;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameispaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }

    private void pause()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }

    public void Loadmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("options");
    }

    public void Quitgame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}