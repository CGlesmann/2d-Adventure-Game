using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase : MonoBehaviour
{
    [Header("Base State Settings")]
    [SerializeField] protected List<EnemyStateBase> availableStateTransitions;

    public virtual EnemyStateBase HasATransitionAvailable()
    {
        foreach (EnemyStateBase state in availableStateTransitions)
        {
            if (state.IsAvailableForTransition())
            {
                return state;
            }
        }

        return null;
    }
    public virtual bool IsAvailableForTransition() { return false; }

    public virtual void OnEnemyStateEnter() { return; }
    public virtual void OnEnemyStateUpdate() { return; }
    public virtual void OnEnemyStateEnd() { return; }
}
