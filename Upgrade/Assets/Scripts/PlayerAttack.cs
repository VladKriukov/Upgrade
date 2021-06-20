using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool waitingForImput;
    private Enemy enemy;
    [SerializeField] float damageAmount = -10;
    private void Update()
    {
        if (waitingForImput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                enemy.enemyhealth(damageAmount);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            waitingForImput = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemy = null;
            waitingForImput = false;
        }
    }
}