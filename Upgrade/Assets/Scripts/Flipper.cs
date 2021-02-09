using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script flips the visuals of the GameObject that calls it
public class Flipper : MonoBehaviour
{
    
    public static Vector2 Flip(Transform transform)
    {
        Vector2 flippingScale = transform.localScale;
        flippingScale.x *= -1;
        return flippingScale;
    }

}
