﻿using UnityEngine;

[RequireComponent(typeof(Health))]
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

    private void Start()
    {
        QualitySettings.vSyncCount = 1; // enable vsync
        Inventory.showShop = false; // hide shop
        respawnPoint = transform.position;
        health = GetComponent<Health>();
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