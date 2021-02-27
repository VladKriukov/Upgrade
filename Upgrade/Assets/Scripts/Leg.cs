using UnityEngine;

public class Leg : MonoBehaviour
{
    private StickmanController stickmanController;

    private void Awake()
    {
        stickmanController = transform.parent.GetComponent<StickmanController>();
        if (!stickmanController) Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        stickmanController.collisions++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        stickmanController.collisions--;
    }
}