using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] GameObject collectables;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemies;
    PuzzleDoor[] doors;

    int numberOfCollectables;
    int numberOfEnemies;

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        doors = FindObjectsOfType<PuzzleDoor>();
        if (collectables != null) numberOfCollectables = collectables.transform.childCount;
        if (enemies != null) numberOfEnemies = enemies.transform.childCount;
    }

    public void Save()
    {
        Debug.Log("Save");
        if (collectables != null)
        {
            for (int i = 0; i < numberOfCollectables-1; i++)
            {
                if (collectables.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Collectable" + i + "active_" + SceneManager.GetActiveScene().name, 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Collectable" + i + "active_" + SceneManager.GetActiveScene().name, 0);
                    Debug.Log("Coin " + i + " disabled in hirearchy");
                }
            }
        }
        
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX_" + SceneManager.GetActiveScene().name, player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY_" + SceneManager.GetActiveScene().name, player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ_" + SceneManager.GetActiveScene().name, player.transform.position.z);
        }

        if (enemies != null)
        {
            for (int i = 0; i < numberOfEnemies-1; i++)
            {
                if (enemies.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Enemy" + i + "active_" + SceneManager.GetActiveScene().name, 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Enemy" + i + "active_" + SceneManager.GetActiveScene().name, 0);
                }
            }
        }

        if (doors.Length > 0)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].isUnlocked == true)
                {
                    PlayerPrefs.SetInt("Door" + i + "unlocked_" + SceneManager.GetActiveScene().name, 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Door" + i + "unlocked_" + SceneManager.GetActiveScene().name, 0);
                }
            }
        }

        PlayerPrefs.Save();
    }
    
    private void Load()
    {
        if (!PlayerPrefs.HasKey("PlayerX_" + SceneManager.GetActiveScene().name)) return;
        Debug.Log("Load");
        if (collectables != null)
        {
            numberOfCollectables = collectables.transform.childCount;
            for (int i = 0; i < collectables.transform.childCount; i++)
            {
                if (PlayerPrefs.GetInt("Collectable" + i + "active_" + SceneManager.GetActiveScene().name) == 0)
                {
                    collectables.transform.GetChild(i).gameObject.SetActive(false);
                    Debug.Log("Coin " + i + " disabled in hirearchy");
                }
            }
        }

        if (player != null)
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX_" + SceneManager.GetActiveScene().name), PlayerPrefs.GetFloat("PlayerY_" + SceneManager.GetActiveScene().name), PlayerPrefs.GetFloat("PlayerZ_" + SceneManager.GetActiveScene().name));
        }

        if (enemies != null)
        {
            numberOfEnemies = enemies.transform.childCount;
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                if (PlayerPrefs.GetInt("Enemy" + i + "active_" + SceneManager.GetActiveScene().name) == 0)
                {
                    enemies.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        if (doors.Length > 0)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (PlayerPrefs.GetInt("Door" + i + "unlocked_" + SceneManager.GetActiveScene().name) == 1)
                {
                    doors[i].isUnlocked = true;
                }
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Load();
    }
}
