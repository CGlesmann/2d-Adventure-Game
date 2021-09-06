using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementController), typeof(PlayerInputManager))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;

    private PlayerInputManager inputManager;
    private PlayerAnimatorController animationController;
    private MovementController movementController;
    public Vector2 currentInputMoveSpeed { get; private set; }
    private bool canMove = true;

    public void Start()
    {
        movementController = GetComponent<MovementController>();
        animationController = GetComponent<PlayerAnimatorController>();

        EnableWalking();
    }

    public void Update()
    {
        if (canMove && currentInputMoveSpeed != Vector2.zero)
        {
            movementController.Move(transform, currentInputMoveSpeed * moveSpeed * Time.deltaTime);
        }
    }

    private void UpdateWalkSpeed(InputAction.CallbackContext context) { currentInputMoveSpeed = context.ReadValue<Vector2>(); }

    // Pausing Movement allows for Input to continue to be collected without moving the player
    // Example of Use: Player should begin walking immediately after attack completes, use this
    public void PauseMovement() { animationController.PauseWalkAnimationUpdate(); canMove = false; }
    public void UnpauseMovement() { animationController.UnpauseWalkAnimationUpdate(); canMove = true; }

    // Diabling Movement, stops the player movement and input completely
    // Example of Use: NPC Interaction begins, no need for input to be collected in background.
    public void DisableWalking()
    {
        currentInputMoveSpeed = Vector2.zero;

        if (inputManager == null) { inputManager = GetComponent<PlayerInputManager>(); }
        inputManager.UnsubscribeToInputActionEvent("Walking", UpdateWalkSpeed);

        if (animationController == null) { animationController = GetComponent<PlayerAnimatorController>(); }
        animationController.DisableWalkAnimationUpdate();
    }

    public void EnableWalking()
    {
        if (inputManager == null) { inputManager = GetComponent<PlayerInputManager>(); }
        inputManager.SubscribeToInputActionEvent("Walking", UpdateWalkSpeed);

        if (animationController == null) { animationController = GetComponent<PlayerAnimatorController>(); }
        animationController.EnableWalkAnimationUpdate();
        // animationController.EnableDashAnimationUpdate();
    }
}
