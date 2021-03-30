using UnityEngine;

public class Puzzle3Behaviour : MonoBehaviour
{
    private int matchesToWin = 5;
    private int matches;

    public GameObject text;
    public GameObject images;
    public GameObject continueButton;

    private void Update()
    {
        if (matchesToWin == matches)
        {
            text.gameObject.SetActive(true);
            continueButton.SetActive(true);
        }
    }

    public void AddPoints()
    {
        matches++;
        Debug.Log(matches + "/" + matchesToWin);
    }
}