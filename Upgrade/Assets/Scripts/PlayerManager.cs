using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] float bouncerJumpExtra;
    Collectable collectable;
    Upgrade upgrade;
    Vector2 respawnPoint;

    public delegate void Collect(int amount);
    public static event Collect OnCollected;

    public delegate void LevelUp();
    public static event LevelUp OnUpgrade;

    public delegate void Die();
    public static event Die OnDie;

    void Start()
    {
        respawnPoint = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
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
                Respawn();
                break;
            case "Respawn":
                respawnPoint = transform.position;
                break;
            case "Bouncer":
                GetComponent<Movement>().JumpUp(bouncerJumpExtra);
                break;
            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
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

    void Respawn()
    {
        GameManager.lives--;
        OnDie?.Invoke();
        if (GameManager.lives <= 0)
        {
            // play death animation screen
            Invoke(nameof(ReloadLevel), 2f);
        }
        else
        {
            transform.position = respawnPoint;
        }
    }

    void ReloadLevel()
    {
        LevelManager.ReloadLevel();
    }
}
