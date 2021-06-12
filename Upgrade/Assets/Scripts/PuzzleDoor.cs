using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] GameObject instructionText;
    [SerializeField] bool isReturnDoor;
    [SerializeField] SaveSystem save;
    [HideInInspector] public bool isUnlocked;
    public UnityEvent onPuzzleComplete;
    public UnityEvent onDoorUnlocked;
    GameObject mainUI;
    bool awaitingInput;
    int ran;

    private void Start()
    {
        ran = Random.Range(0, transform.GetChild(1).childCount);
        if (save == null) Debug.LogWarning("There is no save system assigned to door!");
        if (isUnlocked)
        {
            onDoorUnlocked.Invoke();
        }

        mainUI = FindObjectOfType<Health>().gameObject;
    }

    private void Update()
    {
        if (awaitingInput == true)
        {
            if (isReturnDoor)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (save != null) save.Save();
                    Invoke(nameof(PreviousLevel), 0.1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (isUnlocked)
                {
                    if (save != null) save.Save();
                    Invoke(nameof(NextLevel), 0.1f);
                }
                else
                {
                    transform.GetChild(1).GetChild(ran).gameObject.SetActive(true);
                    awaitingInput = false;
                    GameManager.inGame = false;
                    mainUI.SetActive(false);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnControls();
        }
    }

    void NextLevel()
    {
        LevelManager.LoadNextLevel();
    }

    void PreviousLevel()
    {
        LevelManager.LoadPreviousLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Door(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Door(false);
        }
    }

    private void Door(bool b)
    {
        instructionText.SetActive(b);
        awaitingInput = b;
        if (isReturnDoor)
        {
            instructionText.GetComponent<TMP_Text>().text = "Press 'W' to go back";
        }
        else
        {
            instructionText.GetComponent<TMP_Text>().text = "Press 'E' to start puzzle";
        }
        if (isUnlocked)
        {
            instructionText.GetComponent<TMP_Text>().text = "Press 'E' to go to next level";
        }
    }

    public void PuzzleComplete()
    {
        isUnlocked = true;
        if (save != null) save.Save();
        onPuzzleComplete.Invoke();
        ReturnControls();
    }

    public void ReturnControls()
    {
        GameManager.inGame = true;
        foreach (Transform item in transform.GetChild(1))
        {
            item.gameObject.SetActive(false);
        }
        mainUI.SetActive(true);
    }
}