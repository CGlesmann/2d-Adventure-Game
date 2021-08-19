using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatStats
{
    public float entityHealth;
    public float entityDefense;

    private float remainingHealth;

    public void InitializeStats()
    {
        remainingHealth = entityHealth;
        Debug.Log($"Starting Health {remainingHealth}");
    }

    public bool IsDefeated() { return remainingHealth <= 0f; }
    public void TakeDamage(float damage) { Debug.Log($"Taking {damage} damage"); remainingHealth -= damage; Debug.Log($"{remainingHealth} remaining health"); }
}
