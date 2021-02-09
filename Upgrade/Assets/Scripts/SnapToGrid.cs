using UnityEngine;

public class SnapToGrid : MonoBehaviour
{

    [SerializeField] Transform followObject;
    [SerializeField] float gridSize = 1;
    [SerializeField] Vector2 offset;
    [SerializeField] Vector3 followObjectOffset;

    void Update()
    {
        if (followObject) Follow();
        Snap();
    }

    void Snap()
    {
        //transform.position = new Vector2((Mathf.Ceil(transform.position.x) + offset.x), (Mathf.Ceil(transform.position.y) + offset.y));
        //transform.position = new Vector2(transform.position.x % gridSize, transform.position.y % gridSize);
        transform.position = new Vector2(Mathf.Round(transform.position.x * gridSize) / gridSize + offset.x, Mathf.Round(transform.position.y * gridSize) / gridSize + offset.y);
    }

    void Follow()
    {
        transform.position = followObject.position + followObjectOffset;
    }

}
