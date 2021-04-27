using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float startingHP = 100f;
    public float hp;

    public UnityEvent OnHealthChanged;

    private void Awake()
    {
        ResetHealth();
    }

    public void ChangeHealth(float amount)
    {
        Debug.Log("Current health (" + hp + ") adds " + amount + " to hp");
        GameManager.playerHealth += amount;
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