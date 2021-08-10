using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseInteraction : MonoBehaviour
{
    [Header("Base Interaction Settings")]
    public string interactionDisplayText;
    public bool canProgressInteraction = true;

    [Header("Event Refrences")]
    [SerializeField] private UnityEvent onInteractionEnd;
    private List<UnityAction> temporaryActions;

    public virtual void BeginInteraction(UnityAction endAction)
    {
        if (endAction != null)
        {
            if (onInteractionEnd == null) { onInteractionEnd = new UnityEvent(); }
            if (temporaryActions == null) { temporaryActions = new List<UnityAction>(); }

            temporaryActions.Add(endAction);
            onInteractionEnd.AddListener(endAction);
        }

        return;
    }

    public virtual void ProgressInteraction() { return; }

    public virtual bool IsInteractionComplete() { return true; }

    public virtual void EndInteraction()
    {
        onInteractionEnd?.Invoke();
        if (temporaryActions != null && temporaryActions.Count > 0)
        {
            foreach (UnityAction action in temporaryActions)
            {
                onInteractionEnd.RemoveListener(action);
            }

            temporaryActions.Clear();
        }

        return;
    }
}
