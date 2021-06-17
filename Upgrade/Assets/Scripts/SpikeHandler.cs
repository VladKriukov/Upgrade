using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{
    int stoodAmount;
    SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        stoodAmount++;

        switch (stoodAmount)
        {
            case 1:
                sr.color= new Color(1F, 0.64F, 0.0F); // Orange
                break;
            case 2:
                sr.color = Color.yellow;
                break;
            case 3:
                Destroy(gameObject);
                break;
            default:
                sr.color = Color.red;
                break;
        }
    }
}