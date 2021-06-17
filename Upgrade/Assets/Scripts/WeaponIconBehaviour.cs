using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIconBehaviour : MonoBehaviour
{
    Sprite spr;

    [SerializeField] private Sprite[] icons;

    void Start()
    {
        spr = gameObject.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)){

            if (gameObject.GetComponent<Image>().sprite == icons[0]) // set to bow
            {
                gameObject.GetComponent<Image>().sprite = icons[1];

                PlayerManager.itemEquipped = 1;
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = icons[0]; // set to sword

                PlayerManager.itemEquipped = 2;
            }
        }
    }
}