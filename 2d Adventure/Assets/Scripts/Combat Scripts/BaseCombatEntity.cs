using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class BaseCombatEntity : MonoBehaviour
{
    [Header("Base Entity Stats")]
    [SerializeField] protected CombatStats combatStats;

    protected virtual void Awake()
    {
        combatStats.InitializeStats();
    }

    public virtual bool IsDefeated() { return combatStats.IsDefeated(); }

    public virtual void TakeDamage(float damageAmount)
    {
        combatStats.TakeDamage(damageAmount);
        if (IsDefeated())
        {
            OnDefeat();
        }
    }

    public virtual void OnDefeat() { GameObject.Destroy(gameObject); }
}
