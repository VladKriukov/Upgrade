using UnityEngine;
using UnityEngine.UI;

public class NumberBehaviour : MonoBehaviour
{
    [SerializeField] private Button up;
    [SerializeField] private Button down;
    [SerializeField] private Text text;

    [HideInInspector] public int number;

    private void Start()
    {
        Button upButton = up.GetComponent<Button>();
        Button downButton = down.GetComponent<Button>();
        upButton.onClick.AddListener(upClicked);
        downButton.onClick.AddListener(downClicked);

        number = Random.Range(0, 9);
        text.text = number.ToString();
    }

    private void upClicked()
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

    private void downClicked()
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