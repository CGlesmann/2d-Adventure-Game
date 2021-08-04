using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{
    [Header("Base Interaction Settings")]
    public string interactionDisplayText;

    public virtual void OnInteractionBegin() 
    {
        Debug.Log("Starting Interaction");
        return;
    }

    public virtual void OnInteractionEnd() 
    {
        Debug.Log("Ending Interaction");
        return;
    }
}   
