using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class AttackCollider : MonoBehaviour
{
    [Header("Collision Settings")]
    [SerializeField] private LayerMask targetLayer;
    private float attackDamage;

    public void InitializeAttackCollider(float attackDamage)
    {
        this.attackDamage = attackDamage;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            BaseCombatEntity targetEntity = other.gameObject.GetComponent<BaseCombatEntity>();
            if (targetEntity == null) { return; }

            targetEntity.TakeDamage(attackDamage);
        }
    }
}
