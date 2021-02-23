using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            FindObjectOfType<KeyManagement>().keypickup();
            Destroy(gameObject);
        }
    }
}