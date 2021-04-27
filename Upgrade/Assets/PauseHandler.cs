using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    bool Paused = false;
    [SerializeField] GameObject blur;
    [SerializeField] GameObject UI;

    void Start()
    {
        
    }



    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                blur.SetActive(false);
                UI.SetActive(true);
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                blur.SetActive(true);
                UI.SetActive(false);
                Paused = true;
            }
        }
    }
}