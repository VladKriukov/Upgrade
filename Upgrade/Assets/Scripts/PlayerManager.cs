using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float jumpPadJumpMultiplier;
    [SerializeField] int forceAmount;
    private Collectable collectable;
    private Vector2 respawnPoint;
    private Health health;

    public delegate void Collect(int amount);

    public static event Collect OnCollected;

    public delegate void Die();

    public static event Die OnDie;


    Vector2 direction;
    Rigidbody2D rb;

    private void Start()
    {
        QualitySettings.vSyncCount = 1; // enable vsync
        Inventory.showShop = false; // hide shop
        respawnPoint = transform.position;
        health = FindObjectOfType<Health>();

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectable = collision.GetComponent<Collectable>();

        if (collectable)
        {
            collectable.Collect();
            OnCollected?.Invoke(collectable.value);
        }

        switch (collision.tag)
        {
            case "Danger":
                TakeDamage(25);
                direction = rb.transform.position - collision.transform.position;
                rb.AddForce(direction.normalized * forceAmount);
                break;
            case "Respawn":
                respawnPoint = transform.position;
                break;
            case "JumpPad":
                GetComponent<Movement>().JumpUp(jumpPadJumpMultiplier);
                break;
            default:
                break;
        }
    }

    private void TakeDamage (float damage)
    {
        health.ChangeHealth(-damage);
        Respawn();
    }

    private void Respawn()
    {
        OnDie?.Invoke();
        if (GameManager.playerHealth <= 0)
        {
            // play death animation screen, disable movement
            GameManager.inGame = false;
            Invoke(nameof(ReloadLevel), 2f);
        }
        else
        {
            transform.position = respawnPoint;
        }
    }

    private void ReloadLevel()
    {
        LevelManager.ReloadLevel();
        GameManager.inGame = true;
        health.ResetHealth();
    }
}