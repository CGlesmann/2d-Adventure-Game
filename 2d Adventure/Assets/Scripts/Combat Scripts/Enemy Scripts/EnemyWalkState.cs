using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyStateBase
{
    [Header("Enemy Walk State Settings")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float walkTime;
    [SerializeField] private float idleTime;

    [Header("Enemy Transition References")]
    [SerializeField] private LayerMask hostileLayer;
    [SerializeField] private float walkTransitionDistance;

    private MovementController movementController;
    private Vector2 movementVector;
    private float remainingIdleTime;
    private float remainingWalkTime;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    public override bool IsAvailableForTransition()
    {
        return !Physics2D.BoxCast(transform.position, Vector2.one * walkTransitionDistance, 0f, Vector2.zero, 0f, hostileLayer);
    }

    public override void OnEnemyStateEnter()
    {
        base.OnEnemyStateEnter();

        movementVector = Vector2.zero;
        remainingIdleTime = idleTime;
        remainingWalkTime = 0;
    }

    public override void OnEnemyStateUpdate()
    {
        if (remainingIdleTime > 0f)
        {
            remainingIdleTime -= Time.deltaTime;
            if (remainingIdleTime <= 0f)
            {
                movementVector = GetRandomMovementVector();
                remainingWalkTime = walkTime;
            }

            return;
        }

        remainingWalkTime -= Time.deltaTime;
        movementController.Move(transform, movementVector * walkSpeed * Time.deltaTime);

        if (remainingWalkTime <= 0f)
        {
            movementVector = Vector2.zero;
            remainingIdleTime = idleTime;
        }

        return;
    }

    private Vector2 GetRandomMovementVector()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
