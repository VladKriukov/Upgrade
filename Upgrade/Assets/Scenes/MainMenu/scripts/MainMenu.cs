using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Loadopeninglevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadsettingsMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void loadmainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void exitgame()
    {
        Application.Quit();
    }
}