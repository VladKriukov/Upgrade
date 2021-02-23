using UnityEngine;

// use PixelPerfect asset instead
public class SnapToGrid : MonoBehaviour
{
    [SerializeField] private Transform followObject;
    [SerializeField] private float gridSize = 1;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Vector3 followObjectOffset;

    private void Update()
    {
        if (followObject) Follow();
        Snap();
    }

    private void Snap()
    {
        //transform.position = new Vector2((Mathf.Ceil(transform.position.x) + offset.x), (Mathf.Ceil(transform.position.y) + offset.y));
        //transform.position = new Vector2(transform.position.x % gridSize, transform.position.y % gridSize);
        transform.position = new Vector2(Mathf.Round(transform.position.x * gridSize) / gridSize + offset.x, Mathf.Round(transform.position.y * gridSize) / gridSize + offset.y);
    }

    private void Follow()
    {
        transform.position = followObject.position + followObjectOffset;
    }
}