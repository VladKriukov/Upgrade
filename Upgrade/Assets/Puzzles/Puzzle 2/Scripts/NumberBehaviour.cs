using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBehaviour : MonoBehaviour
{
    [SerializeField] Button up;
    [SerializeField] Button down;
    [SerializeField] Text text;

    [HideInInspector] public int number;

    void Start()
    {
        Button upButton = up.GetComponent<Button>();
        Button downButton = down.GetComponent<Button>();
        upButton.onClick.AddListener(upClicked);
        downButton.onClick.AddListener(downClicked);

        number = Random.Range(0, 9);
        text.text = number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  upClicked()
    {
        if (number == 9)
        {
            number = 0;
        }
        else
        {
            number++;
        }
        text.text = number.ToString();
    }

    void downClicked()
    {
        if (number == 0)
        {
            number = 9;
        }
        else
        {
            number--;
        }
        text.text = number.ToString();
    }
}
