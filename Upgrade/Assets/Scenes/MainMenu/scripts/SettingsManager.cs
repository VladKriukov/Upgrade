using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreentoggle;
    public Dropdown resolutiondropdown;

    public Slider musicvolumeslider;
    public Button applybutton;
    public AudioSource musicsource;
    public Resolution[] resolution;
    public Gamesettings gamesettings;

    private void OnEnable()
    {
        gamesettings = new Gamesettings();
        fullscreentoggle.onValueChanged.AddListener(delegate { onfullscreentoggle(); });
        resolutiondropdown.onValueChanged.AddListener(delegate { onresolutionchange(); });

        musicvolumeslider.onValueChanged.AddListener(delegate { onmusicvolume(); });
        resolution = Screen.resolutions;
        applybutton.onClick.AddListener(delegate { onapplybuttonclick(); });
        foreach (Resolution resolution in resolution)
        {
            resolutiondropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        loadsettings();
    }

    public void onfullscreentoggle()
    {
        gamesettings.fullscreen = Screen.fullScreen = fullscreentoggle.isOn;
    }

    public void onresolutionchange()
    {
        Screen.SetResolution(resolution[resolutiondropdown.value].width, resolution[resolutiondropdown.value].height, Screen.fullScreen);
    }

    public void onmusicvolume()
    {
        musicsource.volume = gamesettings.musicvolume = musicvolumeslider.value;
    }

    public void onapplybuttonclick()
    {
        savesettings();
    }

    public void savesettings()
    {
        string jsonData = JsonUtility.ToJson(gamesettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
        PlayerPrefs.SetFloat("musicvolume", musicvolumeslider.value);
        PlayerPrefs.Save();
    }

    public void loadsettings()
    {

    }
}