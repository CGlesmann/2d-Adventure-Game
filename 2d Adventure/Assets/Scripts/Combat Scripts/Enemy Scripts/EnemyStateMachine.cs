using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [Header("State Machine Settings")]
    [SerializeField] private EnemyStateBase startingState;

    private EnemyStateBase currentState = null;

    private void Awake()
    {
        InitializeStateMachine();
    }

    public void InitializeStateMachine()
    {
        if (startingState == null) { Debug.LogError($"No Starting State available for {gameObject.name}"); return; }

        currentState = startingState;
        currentState.OnEnemyStateEnter();
    }

    private void Update()
    {
        if (currentState == null) { return; }

        EnemyStateBase newTargetState = currentState.HasATransitionAvailable();
        if (newTargetState)
        {
            currentState.OnEnemyStateEnd();
            newTargetState.OnEnemyStateEnter();

            currentState = newTargetState;
        }

        currentState.OnEnemyStateUpdate();
    }
}
