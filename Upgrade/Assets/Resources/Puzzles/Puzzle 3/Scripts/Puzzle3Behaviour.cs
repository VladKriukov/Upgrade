using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Behaviour : MonoBehaviour
{

    private int matchesToWin=5;
    private int matches;

    public GameObject text;
    public GameObject images;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (matchesToWin == matches)
        {
            text.gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        matches++;
        Debug.Log(matches + "/" + matchesToWin);
    }
}
