using UnityEngine;
using UnityEngine.UI;

public class HeathDisplay : MonoBehaviour
{
    private int health = 5;
    public Text healthtext;

    private void Update()
    {
        healthtext.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}