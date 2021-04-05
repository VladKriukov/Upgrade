using UnityEngine;
using UnityEngine.Events;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] GameObject instructionText;
    [SerializeField] GameObject mainUI;
    public UnityEvent onPuzzleComplete;
    bool awaitingInput;
    int ran;

    private void Start()
    {
        ran = Random.Range(0, transform.GetChild(1).childCount);
    }

    private void Update()
    {
        if (awaitingInput == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {                
                transform.GetChild(1).GetChild(ran).gameObject.SetActive(true);
                awaitingInput = false;
                GameManager.inGame = false;
                mainUI.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnControls();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            instructionText.SetActive(true);
            awaitingInput = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            instructionText.SetActive(false);
            awaitingInput = false;
        }
    }

    public void PuzzleComplete()
    {
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