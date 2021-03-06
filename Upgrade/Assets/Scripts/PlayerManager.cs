﻿using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float jumpPadJumpMultiplier;
    [SerializeField] private int forceAmount;
    private Collectable collectable;
    private Vector2 respawnPoint;
    private Health health;

    public delegate void Collect(int amount);

    public static event Collect OnCollected;

    public delegate void Die();

    public static event Die OnDie;

    public float damage = 5;
    public static int itemEquipped = 2; // 0 = none, 1 = sword, 2 = bow

    private Vector2 direction;
    private Rigidbody2D rb;

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
                TakeDamage(25, collision);
                break;
            case "Respawn":
                respawnPoint = transform.position;
                break;
            case "JumpPad":
                GetComponent<Movement>().JumpUp(jumpPadJumpMultiplier);
                break;
            case "enemy":
                TakeDamage(20, collision);
                break;
            default:
                break;
        }
    }

    public void TakeDamage(float damage, Collider2D collision)
    {
        health.ChangeHealth(-damage);
        direction = rb.transform.position - collision.transform.position;
        rb.AddForce(direction.normalized * forceAmount);
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