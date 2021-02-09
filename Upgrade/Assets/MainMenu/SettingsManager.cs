﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreentoggle;
    public Dropdown resolutiondropdown;
    
    public Dropdown vsyncdropdown;
    public Slider musicvolumeslider;
    public Button applybutton;
    public AudioSource musicsource;
    public Resolution[] resolution;
    public Gamesettings gamesettings;
    void OnEnable()
    {
        gamesettings = new Gamesettings();
        fullscreentoggle.onValueChanged.AddListener(delegate { onfullscreentoggle(); });
        resolutiondropdown.onValueChanged.AddListener(delegate { onresolutionchange(); });
       
        vsyncdropdown.onValueChanged.AddListener(delegate { onvsyncchange(); });
        musicvolumeslider.onValueChanged.AddListener(delegate { onmusicvolume(); });
        resolution = Screen.resolutions;
        applybutton.onClick.AddListener(delegate { onapplybuttonclick(); });
        foreach(Resolution resolution in resolution)
        {
            resolutiondropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        loadsettings();
    }
    public void onfullscreentoggle()
    {
        
       gamesettings.fullscreen=Screen.fullScreen = fullscreentoggle.isOn;
    }
    public void onresolutionchange()
    {
        Screen.SetResolution(resolution[resolutiondropdown.value].width, resolution[resolutiondropdown.value].height, Screen.fullScreen);
    }
    
    public void onvsyncchange()
    {
        QualitySettings.vSyncCount = gamesettings.vsync = vsyncdropdown.value;
    }
    public void onmusicvolume()
    {
        musicsource.volume = gamesettings.musicvolume= musicvolumeslider.value;
    }
    public void onapplybuttonclick()
    {
        savesettings();
    }
    public void savesettings()
    {
        string jsonData = JsonUtility.ToJson(gamesettings,true);
        File.WriteAllText(Application.persistentDataPath+ "/gamesettings.json",jsonData);
        PlayerPrefs.SetFloat("musicvolume", musicvolumeslider.value);
        PlayerPrefs.SetInt("vsync", vsyncdropdown.value);
        PlayerPrefs.Save();
    }
    public void loadsettings()
    {
        if (PlayerPrefs.HasKey("vsync"))
        {
            gamesettings = JsonUtility.FromJson<Gamesettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
            musicvolumeslider.value = gamesettings.musicvolume;

            vsyncdropdown.value = gamesettings.vsync;
            resolutiondropdown.value = gamesettings.resolutionindex;
            fullscreentoggle.isOn = gamesettings.fullscreen;
            Screen.fullScreen = gamesettings.fullscreen;
        }
        
    }
}
