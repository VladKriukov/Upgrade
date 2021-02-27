using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!Puzzle1Behaviour.won)
            transform.Rotate(0f, 0f, 90f);
    }
}