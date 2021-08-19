using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : BaseCombatEntity
{
    public delegate void OnAttackFinish();
    public event OnAttackFinish onAttackFinish;

    private PlayerInputManager playerInputManager;
    private PlayerMovement playerMovement;
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ExecuteAttackFinish()
    {
        if (onAttackFinish != null)
        {
            onAttackFinish();
        }
    }
}
