using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject correctInput;
    private bool moving;
    private bool locked;
    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = transform.localPosition;
    }

    private void Update()
    {
        if (moving)
        {
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                startPosX = mousePos.x - transform.localPosition.x;
                startPosY = mousePos.y - transform.localPosition.y;

                moving = true;
            }
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if (!locked)
        {
            if (Mathf.Abs(transform.localPosition.x - correctInput.transform.localPosition.x) <= 0.5f &&
                Mathf.Abs(transform.localPosition.y - correctInput.transform.localPosition.y) <= 0.5f)
            {
                transform.localPosition = new Vector3(correctInput.transform.localPosition.x, correctInput.transform.localPosition.y, correctInput.transform.localPosition.z);
                locked = true;
                Debug.Log("Correct Position");
                GameObject.Find("GameBehaviour").GetComponent<Puzzle3Behaviour>().AddPoints();
            }
            else
            {
                transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                Debug.Log("Reset Position");
            }
        }
    }
}