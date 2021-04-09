using UnityEngine;
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
        SetupLevel();
    }

    public static void ReloadLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SetupLevel();
    }

    public static void LoadPreviousLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel--;
        SetupLevel();
    }

    private static void SetupLevel()
    {
        SceneManager.LoadScene(currentLevel);
        GameManager.inGame = true;
    }
}