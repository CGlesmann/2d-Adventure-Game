using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyStateBase
{
    [Header("Detection Settings")]
    [SerializeField] private LayerMask hostileLayer;
    [SerializeField] private float aggroRange;
    [SerializeField] private float chaseSpeed;

    [Header("Melee Attack Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDelay;
    [SerializeField] private float attackDamage;

    private BaseCombatEntity target;
    private MovementController movementController;
    private Animator animator;
    private float remainingAttackDelay = 0f;

    private void Start() { animator = GetComponent<Animator>(); }

    public override bool IsAvailableForTransition() { return Physics2D.BoxCast(transform.position, Vector2.one * aggroRange, 0f, Vector2.zero, 0f, hostileLayer); }

    public override void OnEnemyStateEnter()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * aggroRange, 0f, Vector2.zero, 0f, hostileLayer);
        if (hit)
        {
            target = hit.collider.transform.GetComponent<BaseCombatEntity>();
            movementController = transform.GetComponent<MovementController>();
        }
    }

    public override void OnEnemyStateUpdate()
    {
        if (target == null)
        {
            animator.SetBool("Execute_Melee", false);
            return;
        }

        if (Vector2.Distance(transform.position, target.transform.position) > attackRange)
        {
            animator.SetBool("Execute_Melee", false);
            movementController.Move(transform, (target.transform.position - transform.position).normalized * chaseSpeed * Time.deltaTime);

            return;
        }

        if (remainingAttackDelay <= 0f) { animator.SetBool("Execute_Melee", true); }
        else
        {
            animator.SetBool("Execute_Melee", false);
            remainingAttackDelay -= Time.deltaTime;
            return;
        }
    }

    public override void OnEnemyStateEnd()
    {
        base.OnEnemyStateEnd();
        animator.SetBool("Execute_Melee", false);
    }

    public void ExecuteMeleeAttack()
    {
        if (target == null) { return; }

        if (Vector2.Distance(transform.position, target.transform.position) < attackRange)
        {
            target.TakeDamage(attackDamage);
            remainingAttackDelay = attackDelay;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one * aggroRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one * attackRange);

    }
#endif
}
