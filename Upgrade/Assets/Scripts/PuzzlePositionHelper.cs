using UnityEngine;

public class PuzzlePositionHelper : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void OnEnable()
    {
        transform.position = target.position + offset;
    }
}