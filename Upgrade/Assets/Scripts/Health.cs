using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float startingHP = 100f;
    public float hp;

    public UnityEvent OnHealthChanged;

    private void Awake()
    {
        hp = startingHP;
    }

    public void ChangeHealth(float amount)
    {
        Debug.Log("Current health (" + hp + ") adds " + amount + " to hp");
        hp += amount;
        OnHealthChanged.Invoke();
    }

    public float GetCurrentHealth()
    {
        return hp;
    }
}