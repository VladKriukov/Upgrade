using UnityEngine;
using UnityEngine.UI;

public class Puzzle4Behaviour : MonoBehaviour
{
    public static bool lockPuzzle = false;
    [SerializeField] private GameObject[] Number;
    [SerializeField] private Text text;
    [SerializeField] private GameObject continueButton;
    public static int currentButton = 1;
    public static bool resetColours;

    private void Update()
    {
        if (resetColours)
        {
            ResetColours();
        }

        if (currentButton == 13)
        {
            lockPuzzle = true;
            Finished();
        }
    }

    private void Finished()
    {
        text.gameObject.SetActive(true);
        for (int i = 0; i < Number.Length; i++)
        {
            Number[i].gameObject.GetComponent<Image>().color = Color.grey;
            resetColours = false;
        }
        continueButton.SetActive(true);
    }

    private void ResetColours()
    {
        if (!lockPuzzle)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                Number[i].gameObject.GetComponent<Image>().color = Color.white;
                resetColours = false;
            }
        }
    }
}