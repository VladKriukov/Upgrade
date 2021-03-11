﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static int currentLevel = 1;

    private void OnDisable()
    {
        PlayerManager.OnUpgrade -= PlayerManager_OnUpgrade;
    }

    private void OnEnable()
    {
        PlayerManager.OnUpgrade += PlayerManager_OnUpgrade;
    }

    private void PlayerManager_OnUpgrade()
    {
        LoadNextLevel();
    }

    public static void LoadNextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}