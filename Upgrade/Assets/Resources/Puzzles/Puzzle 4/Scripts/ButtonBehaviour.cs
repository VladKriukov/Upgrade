using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    private bool lockPuzzle = false;

    private void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = gameObject.name;

        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            GetComponent<Image>().color = Color.white;
        }

        if (Puzzle4Behaviour.lockPuzzle)
        {
            lockPuzzle = true;
        }
    }

    private void OnClick()
    {
        Button btn = gameObject.GetComponent<Button>();
        int buttonNumber = Int32.Parse(gameObject.name);

        if (!lockPuzzle)
        {
            if (Puzzle4Behaviour.currentButton == buttonNumber)
            {
                GetComponent<Image>().color = Color.green;
                Puzzle4Behaviour.currentButton += 1;
                Debug.Log("Correct Button");
            }
            else if (Puzzle4Behaviour.currentButton == (buttonNumber + 1) || GetComponent<Image>().color == Color.green)
            {
                Debug.Log("Already Active");
            }
            else
            {
                Debug.Log("Wrong button, restarting");
                Puzzle4Behaviour.currentButton = 1;
                Puzzle4Behaviour.resetColours = true;
            }
        }
    }
}