using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShopInteraction : BaseInteraction
{
    [Header("Shop Interface Reference")]
    [SerializeField] private GameObject shopCanvasObject;
    [SerializeField] private Selectable defaultShopButton;

    public override void BeginInteraction(GameObject otherInteractor, UnityAction endAction)
    {
        base.BeginInteraction(otherInteractor, endAction);

        shopCanvasObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultShopButton?.gameObject ?? null);

        PlayerInputManager.playerInputManager.SubscribeToInputActionEvent("UICancel", CancelShop);
    }

    public override bool IsInteractionComplete() { return false; }

    public override void EndInteraction()
    {
        shopCanvasObject.SetActive(false);
        PlayerInputManager.playerInputManager.UnsubscribeToInputActionEvent("UICancel", CancelShop);
        base.EndInteraction();
    }

    private void CancelShop(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            EndInteraction();
        }
    }
}
