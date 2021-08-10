using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopInteraction : BaseInteraction
{
    [Header("Shop Interface Reference")]
    [SerializeField] private GameObject shopCanvasObject;

    public override void BeginInteraction(UnityAction endAction)
    {
        base.BeginInteraction(endAction);
        shopCanvasObject.SetActive(true);
    }

    public override bool IsInteractionComplete() { return false; }

    public override void EndInteraction()
    {
        base.EndInteraction();
        shopCanvasObject.SetActive(false);
    }
}
