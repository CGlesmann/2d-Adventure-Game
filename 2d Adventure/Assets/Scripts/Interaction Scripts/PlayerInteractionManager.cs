using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionManager : MonoBehaviour
{
    private PlayerInputManager inputManager;
    private PlayerMovement playerMovement;
    private InteractionManager interactionManager;

    private bool interactionInProgress;

    private void Awake() 
    {
        inputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();

        inputManager.SubscribeToInputActionEvent("NPC_Interact", OnInteract);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        InteractionManager interactionManager = other.GetComponent<InteractionManager>();
        if (interactionManager == null)
        {
            Debug.LogError($"Couldn't find an interaction manager on {other.name}");
            return;
        }

        this.interactionManager = interactionManager;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        this.interactionManager = null;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            Debug.Log($"OnInteract");
            if (!interactionInProgress && interactionManager != null)
            {
                playerMovement.DisableWalking();
                interactionManager.EnableInteractionPanel();

                interactionInProgress = true;
            }
            else if (interactionManager != null)
            {
                interactionManager.onInteractionEnd += OnInteractionFinish;
                interactionManager.ExecuteCurrentlySelectedInteraction();
            }
        }
    }

    public void OnInteractionFinish()
    {
        interactionInProgress = false;
        playerMovement.EnableWalking();
    }
}
