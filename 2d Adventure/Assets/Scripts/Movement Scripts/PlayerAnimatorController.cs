using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorController : MonoBehaviour
{
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

        inputManager.SubscribeToInputActionEvent("Walking", OnWalk);
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
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
