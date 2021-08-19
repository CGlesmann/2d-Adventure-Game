using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorController : MonoBehaviour
{
    private const string WALKING_ACTION_KEY = "Walking";

    private PlayerMovement playerMovement;
    private PlayerInputManager inputManager;
    private Animator anim;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError($"No animator was found for {gameObject.name}");
            return;
        }

        inputManager = GetComponent<PlayerInputManager>();
        if (inputManager == null)
        {
            Debug.LogError($"No Player Input Animator was found for {gameObject.name}");
            return;
        }
    }

    private void OnDestroy() { DisableWalkAnimationUpdate(); }

    public void EnableWalkAnimationUpdate() { inputManager.SubscribeToInputActionEvent(WALKING_ACTION_KEY, OnWalk); }

    public void DisableWalkAnimationUpdate()
    {
        inputManager.UnsubscribeToInputActionEvent(WALKING_ACTION_KEY, OnWalk);
        SetCharacterToIdle();
    }

    public void SetCharacterToIdle()
    {
        UpdateAnimatorWalkingParameters(Vector2.zero);
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (anim == null) { return; }

        Vector2 inputValue = context.ReadValue<Vector2>();
        UpdateAnimatorWalkingParameters(inputValue);
    }

    public void UpdateAnimatorWalkingParameters(Vector2 newMoveSpeed)
    {
        anim.SetBool("Walking", newMoveSpeed != Vector2.zero);

        if (newMoveSpeed == Vector2.zero)
        {
            return;
        }

        anim.SetFloat("Horizontal", newMoveSpeed.x);
        anim.SetFloat("Vertical", newMoveSpeed.y);
        return;
    }
}