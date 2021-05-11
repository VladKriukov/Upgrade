using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    public int value;
    public static int num;
    private Animator animator;

    [SerializeField] float speed = 2f;
    [SerializeField] float height = 0.003f;

    void Start()
    { 
        StartCoroutine(MoveUpAndDown());
    }

   public IEnumerator MoveUpAndDown()
    {

        Vector2 pos = transform.position;

        float newY = Mathf.Sin(Time.unscaledTime * speed) * height + pos.y;

        transform.position = new Vector2(transform.position.x, newY);

        yield return null;

        StartCoroutine(MoveUpAndDown());
    }

    private void OnEnable()
    {
        num++;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Collect()
    {
        if (animator != null)
            animator.Play("Collected");
        else
        {
            gameObject.SetActive(false);
        }

        num--;
        if (num == 0)
        {
            Debug.Log("Collected all coins");
        }
    }
}