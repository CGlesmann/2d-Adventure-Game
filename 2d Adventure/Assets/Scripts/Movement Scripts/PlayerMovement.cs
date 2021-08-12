using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementController), typeof(PlayerInputManager))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;

    private PlayerInputManager inputManager;
    private PlayerAnimatorController animationController;
    private MovementController movementController;
    private Vector2 currentInputMoveSpeed = Vector3.zero;

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        animationController = GetComponent<PlayerAnimatorController>();

        EnableWalking();
    }

    public void Update()
    {
        if (currentInputMoveSpeed != Vector2.zero)
        {
            movementController.Move(transform, currentInputMoveSpeed * moveSpeed * Time.deltaTime);
        }
    }

    private void UpdateWalkSpeed(InputAction.CallbackContext context)
    {
        currentInputMoveSpeed = context.ReadValue<Vector2>();
    }

    public void EnableWalking()
    {
        if (inputManager == null) { inputManager = GetComponent<PlayerInputManager>(); }
        inputManager.SubscribeToInputActionEvent("Walking", UpdateWalkSpeed);

        if (animationController == null) { animationController = GetComponent<PlayerAnimatorController>(); }
        animationController.EnableWalkAnimationUpdate();
    }

    public void DisableWalking()
    {
        currentInputMoveSpeed = Vector2.zero;

        if (inputManager == null) { inputManager = GetComponent<PlayerInputManager>(); }
        inputManager.UnsubscribeToInputActionEvent("Walking", UpdateWalkSpeed);

        if (animationController == null) { animationController = GetComponent<PlayerAnimatorController>(); }
        animationController.DisableWalkAnimationUpdate();
    }
}
