using UnityEngine;

public class UICamera : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    Camera thisCamera;

    private void Awake()
    {
        thisCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        thisCamera.fieldOfView = mainCamera.fieldOfView;
    }
}