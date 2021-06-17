using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locator : MonoBehaviour
{
    flyenemy flyenemy;

    // Start is called before the first frame update
    void Start()
    {
        flyenemy = FindObjectOfType<flyenemy>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
