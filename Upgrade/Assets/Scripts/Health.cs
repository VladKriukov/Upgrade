using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float startingHP = 100f;

    public UnityEvent OnHealthChanged;

    private void Awake()
    {
        ResetHealth();
    }

    public void ChangeHealth(float amount)
    {
        GameManager.playerHealth += amount;
        Debug.Log("Current health (" + (GameManager.playerHealth - amount) + ") adds " + amount + " to hp. Result: " + GameManager.playerHealth);
        OnHealthChanged.Invoke();
    }

    public float GetCurrentHealth()
    {
        return GameManager.playerHealth;
    }

    public void ResetHealth()
    {
        GameManager.playerHealth = startingHP;
    }
}