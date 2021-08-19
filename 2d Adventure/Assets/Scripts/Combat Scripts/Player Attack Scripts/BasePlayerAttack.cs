using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayerAttack : MonoBehaviour
{
    [Header("Attack Input Settings")]
    [SerializeField] protected PlayerCombatController playerCombatController;
    [SerializeField] protected PlayerInputManager playerInputManager;
    [SerializeField] protected string attackInputKey;

    [Header("Base Attack Stats")]
    [SerializeField] protected float baseAttackPower;
    [SerializeField] protected float baseAttackCooldown;

    protected float currentCooldownRemaining = 0;
    protected bool isActive = false;

    public void DeactivateAttackInput() { playerInputManager.UnsubscribeToInputActionEvent(attackInputKey, TryAttackBegin); }
    public void ActivateAttackInput() { playerInputManager.SubscribeToInputActionEvent(attackInputKey, TryAttackBegin); }

    protected virtual void Awake()
    {
        playerCombatController.onAttackFinish += OnAttackEnd;
        ActivateAttackInput();
    }

    protected void Update()
    {
        if (currentCooldownRemaining > 0) { currentCooldownRemaining -= Time.deltaTime; return; }

        if (isActive)
        {
            OnAttackUpdate();
        }
    }

    public virtual void TryAttackBegin(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            if (IsAvailableForUse() && !isActive)
            {
                isActive = true;
                OnAttackBegin();
            }
        }
    }

    public virtual void OnAttackBegin() { }
    public virtual void OnAttackUpdate() { }
    public virtual void OnAttackEnd()
    {
        isActive = false;
        currentCooldownRemaining = baseAttackCooldown;
    }

    public virtual bool IsAvailableForUse() { return currentCooldownRemaining <= 0f; }
}
