using UnityEngine;

// This script makes sure the GameObject attatched "Don't Destroy On Load" whenever any scene loads
public class DDOL : MonoBehaviour
{
    private void Awake()
    {
        DDOL[] objs = FindObjectsOfType<DDOL>();
        if (objs.Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}