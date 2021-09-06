using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class AttackCollider : MonoBehaviour
{
    [Header("Collision Settings")]
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float knockbackAmount;
    private float attackDamage;
    private int amountOfAttacks;
    private float delayBetweenAttacks;

    private Dictionary<GameObject, int> remainingAttacks;
    private Transform parentTransform;
    private float remainingDelay;

    public void InitializeAttackCollider(Transform parentTransform, float attackDamage)
    {
        this.parentTransform = parentTransform;
        this.attackDamage = attackDamage;
        remainingDelay = 0f;

        remainingAttacks = new Dictionary<GameObject, int>();
    }

    public void SetAmountOfAttacks(int amountOfAttacks, float delayBetweenAttacks)
    {
        this.amountOfAttacks = amountOfAttacks;
        this.delayBetweenAttacks = delayBetweenAttacks;
    }

    private void Update()
    {
        if (remainingDelay > 0f) { remainingDelay -= Time.deltaTime; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D AttackCollider");
        if (remainingDelay <= 0f && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            int remainingAttacksForGameObject;
            if (!remainingAttacks.ContainsKey(other.gameObject))
            {
                remainingAttacks.Add(other.gameObject, amountOfAttacks - 1);
                remainingAttacksForGameObject = amountOfAttacks;
            }
            else
            {
                remainingAttacksForGameObject = remainingAttacks[other.gameObject];
                if (remainingAttacksForGameObject > 0)
                {
                    remainingAttacks[other.gameObject] -= 1;
                }
            }

            if (remainingAttacksForGameObject > 0)
            {
                BaseCombatEntity targetEntity = other.gameObject.GetComponent<BaseCombatEntity>();
                if (targetEntity == null) { return; }

                targetEntity.TakeDamage(attackDamage);
                targetEntity.GetComponent<KnockbackController>().BeginKnockback(parentTransform.position, knockbackAmount);

                // Vector2 forceVector = (targetEntity.transform.parent.position - parentTransform.position).normalized * knockbackAmount;
                // Debug.Log(forceVector);
                // targetEntity.transform.parent.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
            }
        }
    }
}
