using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseInteraction : MonoBehaviour
{
    [Header("Base Interaction Settings")]
    public string interactionDisplayText;

    [Header("Event Refrences")]
    [SerializeField] private UnityEvent onInteractionEnd;

    public virtual void BeginInteraction() { return; }

    public virtual void ProgressInteraction() { return; }

    public virtual bool IsInteractionComplete() { return true; }

    public virtual void EndInteraction()
    {
        onInteractionEnd?.Invoke();
        return;
    }
}
