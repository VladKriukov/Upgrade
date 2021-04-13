using UnityEngine;
using UnityEngine.UI;

public class Puzzle2Behaviour : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button button;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private Button submit;
    [SerializeField] private GameObject numberOne, numberTwo, numberThree, numberFour;

    private int doorNumber;

    private int firstNumber, secondNumber, thirdNumber, fourthNumber;

    private void Start()
    {
        Button buttonComponent = button.GetComponent<Button>();
        Button submitComponent = submit.GetComponent<Button>();
        buttonComponent.onClick.AddListener(DebugButtonClick);
        submitComponent.onClick.AddListener(compareValues);

        doorNumber = Random.Range(1000, 9999);
        firstNumber = (int)char.GetNumericValue(doorNumber.ToString()[0]);
        secondNumber = (int)char.GetNumericValue(doorNumber.ToString()[1]);
        thirdNumber = (int)char.GetNumericValue(doorNumber.ToString()[2]);
        fourthNumber = (int)char.GetNumericValue(doorNumber.ToString()[3]);

        text.text = "Door Number: " + doorNumber;
    }

    private void compareValues()
    {
        Debug.Log(firstNumber + "/" + numberOne.GetComponent<NumberBehaviour>().number);
        Debug.Log(secondNumber + "/" + numberTwo.GetComponent<NumberBehaviour>().number);
        Debug.Log(thirdNumber + "/" + numberThree.GetComponent<NumberBehaviour>().number);
        Debug.Log(fourthNumber + "/" + numberFour.GetComponent<NumberBehaviour>().number);

        if (numberOne.GetComponent<NumberBehaviour>().number == firstNumber)
            Debug.Log("First Number Matched");
        {
            if (numberTwo.GetComponent<NumberBehaviour>().number == secondNumber)
                Debug.Log("Second Number Matched");
            {
                if (numberThree.GetComponent<NumberBehaviour>().number == thirdNumber)
                    Debug.Log("Third Number Matched");
                {
                    if (numberFour.GetComponent<NumberBehaviour>().number == fourthNumber)
                    {
                        Debug.Log("Fourth Number Matched");
                        text.text = "Opened Door";
                        continueButton.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    private void DebugButtonClick()
    {
        doorNumber = Random.Range(1000, 9999);
        text.text = "Door Number: " + doorNumber;

        firstNumber = (int)char.GetNumericValue(doorNumber.ToString()[0]);
        secondNumber = (int)char.GetNumericValue(doorNumber.ToString()[1]);
        thirdNumber = (int)char.GetNumericValue(doorNumber.ToString()[2]);
        fourthNumber = (int)char.GetNumericValue(doorNumber.ToString()[3]);
    }
}