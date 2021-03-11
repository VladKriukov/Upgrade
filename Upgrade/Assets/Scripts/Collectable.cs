using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int value;
    public static int num;
    private Animator animator;

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
            LevelManager.LoadNextLevel();
        }

        Destroy(gameObject, 2f);
    }
}