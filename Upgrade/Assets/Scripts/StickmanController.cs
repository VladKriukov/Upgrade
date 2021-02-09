using System;
using UnityEngine;

public class StickmanController : MonoBehaviour
{

    [SerializeField] Muscle[] muscles;

    [SerializeField] bool right = false;
    [SerializeField] bool left = false;

    [SerializeField] Rigidbody2D upperRightLeg;
    [SerializeField] Rigidbody2D upperLeftLeg;

    [SerializeField] Vector2 walkRightVector;
    [SerializeField] Vector2 walkLeftVector;

    [SerializeField] float jumpStrength;

    [SerializeField] float moveDelay;
    float moveDelayPointer;

    [HideInInspector] public int collisions;

    void Update()
    {
        foreach (var _muscle in muscles)
        {
            _muscle.ActivateMuscle();
        }

        Walk();

        Jump();
    }

    void Walk()
    {
        right = Input.GetKey(KeyCode.D);
        left = Input.GetKey(KeyCode.A);

        while ((right == true) && (left == false) && Time.time > moveDelayPointer)
        {
            Invoke(nameof(Step1Right), 0f);
            Invoke(nameof(Step2Right), 0.09f);
            moveDelayPointer = Time.time + moveDelay;
        }

        while ((left == true) && (right == false) && Time.time > moveDelayPointer)
        {
            Invoke(nameof(Step1Left), 0f);
            Invoke(nameof(Step2Left), 0.09f);
            moveDelayPointer = Time.time + moveDelay;
        }
    }

    void Jump()
    {
        if (collisions > 0 && Input.GetKey(KeyCode.Space))
        {
            upperRightLeg.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
            upperLeftLeg.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
        }
    }

    void Step1Right()
    {
        upperRightLeg.AddForce(walkRightVector, ForceMode2D.Impulse);
        upperLeftLeg.AddForce(walkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    void Step2Right()
    {
        upperLeftLeg.AddForce(walkRightVector, ForceMode2D.Impulse);
        upperRightLeg.AddForce(walkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    void Step1Left()
    {
        upperRightLeg.AddForce(walkLeftVector, ForceMode2D.Impulse);
        upperLeftLeg.AddForce(walkLeftVector * -0.5f, ForceMode2D.Impulse);
    }

    void Step2Left()
    {
        upperLeftLeg.AddForce(walkLeftVector, ForceMode2D.Impulse);
        upperRightLeg.AddForce(walkLeftVector * -0.5f, ForceMode2D.Impulse);
    }

}

[Serializable]
public class Muscle
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;

    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }
}