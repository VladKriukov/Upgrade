using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputManager : MonoBehaviour
{
    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        movement.horizontal = Input.GetAxis("Horizontal");
        movement.vertical = Input.GetAxis("Vertical");
        movement.jump = Input.GetKey(KeyCode.Space);
        movement.leftShift = Input.GetKey(KeyCode.LeftShift);
    }
}