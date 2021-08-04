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
    private MovementController movementController;
    private Vector2 currentInputMoveSpeed = Vector3.zero;

    public void Awake()
    {
        movementController = GetComponent<MovementController>();

        inputManager = GetComponent<PlayerInputManager>();
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

    public void EnableWalking() {inputManager.SubscribeToInputActionEvent("Walking", UpdateWalkSpeed);}
    public void DisableWalking() {inputManager.UnsubscribeToInputActionEvent("Walking", UpdateWalkSpeed);}
}
