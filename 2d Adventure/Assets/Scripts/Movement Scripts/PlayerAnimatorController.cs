using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorController : MonoBehaviour
{
    private const string WALKING_ACTION_KEY = "Walking";

    private PlayerInputManager inputManager;
    private Animator anim;

    private void Awake()
    {
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

        EnableWalkAnimationUpdate();
    }

    private void OnDestroy() { DisableWalkAnimationUpdate(); }

    public void EnableWalkAnimationUpdate() { inputManager.SubscribeToInputActionEvent(WALKING_ACTION_KEY, OnWalk); }

    public void DisableWalkAnimationUpdate() { inputManager.UnsubscribeToInputActionEvent(WALKING_ACTION_KEY, OnWalk); }

    public void SetCharacterToIdle() { anim.SetBool("Walking", false); }

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (anim == null) { return; }

        Vector2 inputValue = context.ReadValue<Vector2>();
        anim.SetBool("Walking", inputValue != Vector2.zero);

        if (inputValue == Vector2.zero)
        {
            return;
        }

        anim.SetFloat("Horizontal", inputValue.x);
        anim.SetFloat("Vertical", inputValue.y);
    }
}
