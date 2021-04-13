using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static float playerHealth = 3;
    public static bool inGame = true;

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}