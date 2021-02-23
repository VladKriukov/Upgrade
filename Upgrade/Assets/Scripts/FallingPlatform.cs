using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Vector2 startingPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.bodyType = RigidbodyType2D.Static;
        startingPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine("Fall");
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        rb.bodyType = RigidbodyType2D.Static;
        boxCollider.enabled = true;
        transform.position = startingPos;
        yield return null;
    }
}