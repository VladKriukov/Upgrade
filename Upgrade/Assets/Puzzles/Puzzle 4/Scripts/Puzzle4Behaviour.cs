using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4Behaviour : MonoBehaviour
{
    public static bool lockPuzzle = false;
    [SerializeField] GameObject[] Number;
    [SerializeField] Text text;
    public static int currentButton = 1;
    public static bool resetColours;

    void Start()
    {

        //  gameObject.GetComponent<Text>().text = number.ToString();

    }


    // Update is called once per frame
    void Update()
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

    void Finished()
    {
        text.gameObject.SetActive(true);
        for (int i = 0; i < Number.Length; i++)
        {
            Number[i].gameObject.GetComponent<Image>().color = Color.grey;
            resetColours = false;
        }
    }
    void ResetColours()
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