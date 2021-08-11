using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public delegate void OnInputActionPerformed(InputAction.CallbackContext ctx);
    public Dictionary<string, OnInputActionPerformed> inputActionMap;

    private PlayerInput playerInput;

    public void EnableInput() { playerInput.Enable(); }
    public void DisbleInput() { playerInput.Disable(); }

    private void OnEnable()
    {
        playerInput = new PlayerInput();

        foreach (InputActionMap actionMap in playerInput.asset.actionMaps)
        {
            actionMap.actionTriggered += OnInputPerformedEvent;
        }

        EnableInput();
    }

    private void OnInputPerformedEvent(InputAction.CallbackContext ctx)
    {
        if (inputActionMap.TryGetValue(ctx.action.name, out OnInputActionPerformed inputActions))
        {
            if (inputActions != null)
            {
                inputActions(ctx);
            }
        }
    }

    public void SubscribeToInputActionEvent(string inputActionName, OnInputActionPerformed inputActionToSubscribe)
    {
        if (inputActionMap == null)
        {
            inputActionMap = new Dictionary<string, OnInputActionPerformed>();
        }

        if (inputActionMap.ContainsKey(inputActionName))
        {
            inputActionMap[inputActionName] += inputActionToSubscribe;
            return;
        }

        inputActionMap.Add(inputActionName, inputActionToSubscribe);
    }

    public void UnsubscribeToInputActionEvent(string inputActionName, OnInputActionPerformed inputActionToSubscribe)
    {
        if (inputActionMap?.ContainsKey(inputActionName) ?? false)
        {
            inputActionMap[inputActionName] -= inputActionToSubscribe;
            return;
        }
    }
}
