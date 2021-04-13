using UnityEngine;

public class PuzzlePositionHelper : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        if (target == null)
        {
            target = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        transform.position = target.position + offset;
    }
}