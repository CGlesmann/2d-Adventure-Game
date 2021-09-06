using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatStats
{
    public float entityHealth;
    public float entityDefense;
    public float damageRecoveryTime;

    [HideInInspector] public float remainingHealth { get; private set; }

    public void InitializeStats() { remainingHealth = entityHealth; }

    public bool IsDefeated() { return remainingHealth <= 0f; }
    public void TakeDamage(float damage) { remainingHealth -= damage; }
}
