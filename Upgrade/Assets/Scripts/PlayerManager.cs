using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float jumpPadJumpMultiplier;
    [SerializeField] int forceAmount;
    private Collectable collectable;
    private Upgrade upgrade;
    private Vector2 respawnPoint;
    private Health health;

    public delegate void Collect(int amount);

    public static event Collect OnCollected;

    public delegate void LevelUp();

    public static event LevelUp OnUpgrade;

    public delegate void Die();

    public static event Die OnDie;

    private void Start()
    {
        respawnPoint = transform.position;
        health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectable = collision.GetComponent<Collectable>();
        upgrade = collision.GetComponent<Upgrade>();

        if (collectable)
        {
            collectable.Collect();
            OnCollected?.Invoke(collectable.value);
        }
        if (upgrade)
        {
            //todo: show mini pop-ups
            if (upgrade.CanUpgrade() == false)
            {
                Debug.Log("More needed");
            }
            else
            {
                Debug.Log("Press Return to upgrade");
            }
        }

        switch (collision.tag)
        {
            case "Danger":
                TakeDamage(5);
                TakeForce();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            upgrade = null;
        }
    }

    private void Update()
    {
        if (upgrade && Input.GetKeyDown(KeyCode.Return))
        {
            UpgradeToNextLevel();
        }
    }

    public void UpgradeToNextLevel()
    {
        if (upgrade)
        {
            OnUpgrade?.Invoke();
        }
    }

    private void TakeDamage (float damage)
    {
        health.ChangeHealth(-damage);
        

    }

    private void TakeForce()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * forceAmount);
    }

    private void Respawn(float damage)
    {
        GameManager.playerHealth = health.GetCurrentHealth();
        OnDie?.Invoke();
        if (GameManager.playerHealth <= 0)
        {
            // play death animation screen, disable movement
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
    }
}