using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAttack : BasePlayerAttack
{
    [Header("Sword Attack References")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;

    private PlayerAnimatorController playerAnimatorController;
    private AttackCollider attackCollider;

    protected override void Awake()
    {
        base.Awake();

        playerAnimatorController = playerMovement.GetComponent<PlayerAnimatorController>();
        attackCollider = GetComponent<AttackCollider>();
    }

    public override void OnAttackBegin()
    {
        base.OnAttackBegin();

        animator.SetTrigger("Sword_Attack");
        attackCollider.InitializeAttackCollider(playerMovement.transform, baseAttackPower);
        attackCollider.SetAmountOfAttacks(1, baseAttackCooldown);
        playerMovement.PauseMovement();
    }

    public override void OnAttackEnd()
    {
        base.OnAttackEnd();

        playerMovement.UnpauseMovement();
    }
}
