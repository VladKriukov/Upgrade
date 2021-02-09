using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputManager : MonoBehaviour
{

    Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        movement.horizontal = Input.GetAxis("Horizontal");
        movement.vertical = Input.GetAxis("Vertical");
        movement.jump = Input.GetKey(KeyCode.Space);
        movement.leftShift = Input.GetKey(KeyCode.LeftShift);
    }

}
