using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;

    private PlayerInput input;
    private MovementController movementController;
    private Vector2 currentInputMoveSpeed = Vector3.zero;

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        input = new PlayerInput();

        input.Movement.Walking.performed += OnWalkPerformed;
        input.Enable();
    }

    public void Update()
    {
        if (currentInputMoveSpeed != Vector2.zero)
        {
            movementController.Move(transform, currentInputMoveSpeed * moveSpeed * Time.deltaTime);
        }
        //transform.position += currentInputMoveSpeed * moveSpeed * Time.deltaTime;
    }

    private void OnWalkPerformed(InputAction.CallbackContext context)
    {
        currentInputMoveSpeed = context.ReadValue<Vector2>();
    }
}
