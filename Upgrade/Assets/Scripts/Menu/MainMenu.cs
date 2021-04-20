using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainCanvas;
    [SerializeField] GameObject OptionsCanvas;
    [SerializeField] AudioMixer masterMixer;

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

    public void ChangeMusicVolume(float volume)
    {
        var result = 20 * Mathf.Log10(volume);
        masterMixer.SetFloat("MusicVolume", result);
    }

    public void ChangeSFXVolume(float volume)
    {
        var result = 20 * Mathf.Log10(volume);
        masterMixer.SetFloat("SFXVolume", result);
    }
}