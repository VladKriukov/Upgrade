using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainCanvas;
    [SerializeField] GameObject OptionsCanvas;

    public void Loadopeninglevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadsettingsMenu()
    {
        MainCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void loadmainmenu()
    {
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void exitgame()
    {
        Application.Quit();
    }
}