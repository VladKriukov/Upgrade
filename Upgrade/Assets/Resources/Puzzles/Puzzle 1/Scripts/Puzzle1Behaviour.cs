using UnityEngine;

public class Puzzle1Behaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] picture;

    [SerializeField] private GameObject text;
    [SerializeField] private GameObject nextButton;
    public static bool won;

    private void Start()
    {
        won = false;
    }

    private void Update()
    {
        if (picture[0].transform.rotation.z == 0 &&
            picture[1].transform.rotation.z == 0 &&
            picture[2].transform.rotation.z == 0 &&
            picture[3].transform.rotation.z == 0 &&
            picture[4].transform.rotation.z == 0 &&
            picture[5].transform.rotation.z == 0)
        {
            won = true;
            text.SetActive(true);
            nextButton.SetActive(true);
        }
    }
}