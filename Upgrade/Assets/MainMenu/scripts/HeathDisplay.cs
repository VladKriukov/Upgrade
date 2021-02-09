using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathDisplay : MonoBehaviour
{
    private int health = 5;
    public Text healthtext;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text =  health.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
